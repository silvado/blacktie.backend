using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Application.Configuration;
using Domain.Entities.Authentication.Common;
using Domain.Exceptions;
using Domain.Interfaces.Authentication;
using Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces.Service;
using Domain.Interfaces.Helpers;
using System.Diagnostics.CodeAnalysis;
using Domain.Interfaces.Repository;
using Application.Contracts.User;
using Mapster;
namespace Application.Services.Authentication
{
    [ExcludeFromCodeCoverage]
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly AuthServiceConfig _authServiceConfig;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IControlRepository _controlRepository;
        private readonly IHashHelper _hash;
        private readonly IControlNumberHelper _control;

        public AuthService(IOptions<AuthServiceConfig> options, IConfiguration configuration, IUserService userService, IHashHelper hash, IControlRepository controlRepository, IControlNumberHelper control)
        {
            _client = new HttpClient();
            _authServiceConfig = options.Value;
            _configuration = configuration;
            _userService = userService;
            _hash = hash;
            _controlRepository = controlRepository;
            _control = control;         
        }

        public async Task<UserSegWeb?> GetUserSession(string sessionId, string codigoOrganizacao)
        {
            var dadosUsuario = await GetUsuario(new SegWebCredential(sessionId, codigoOrganizacao));

            if (!dadosUsuario.IsSuccessStatusCode)
                throw new DomainException("Sessão inválida!");

            var usuarioContent = await dadosUsuario.Content.ReadAsStringAsync();
            JObject jsonContent = JObject.Parse(usuarioContent);

            var usuario = JsonConvert.DeserializeObject<UserSegWeb>(
                    jsonContent["IdentificacaoUsuario"]!.ToString(Formatting.None));

            usuario!.Token = CreateToken(usuario);

            return usuario;
        }

        public async Task<HttpResponseMessage> GetUsuario(SegWebCredential segwebCredencial)
        {
            try
            {
                string json = JsonConvert.SerializeObject(segwebCredencial);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                return await _client.PostAsync(_authServiceConfig.UrlPermissao, data);
            }
            catch (Exception e)
            {
                throw new DomainException("Erro ao recuperar os dados do usuário", e);
            }
        }

        public User? BasicAuthenticate(string email, string password)
        {
            var user = ValidateUser(email, _hash.HashSHA256(password)).GetAwaiter().GetResult();

            if (user is null) {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authServiceConfig.SecretKey!);
           
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email), // Defina o sub conforme sua necessidade
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("RouteAccess", "sistema/config")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),                
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["AuthService:Audience"],
                Issuer = _configuration["AuthService:Issuer"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);

            return user;

        }
       
        public async Task<bool> ValidateControl(Guid userId, string control)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            
            if (user is null) { return false; }

            return await _controlRepository.ValidateControl(user.Id, _hash.HashSHA256(control));
        }

        public async Task<bool> CreateControl(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            
            if (user is null) { return false; }

            var controle = _control.GetControlNumber();

            Control control = new Control
            {
                ExpireAt = DateTime.Now.AddMinutes(10),
                UserId = user.Id,
                ControlNumber = _hash.HashSHA256(Convert.ToString(controle))
            };

            await _controlRepository.AddAndSaveAsync(control);

            //EmailRequest email = new EmailRequest
            //{
            //    ToEmail = user.Email,
            //    Subject = "Ativação de Acesso",
            //    Body = _mailService.CarregaCorpoEmail($"Por favor informe o código <b>{controle}</b> no local indicado no site.")
            //};

            //await _mailService.SendEmailAsync(email);

            return true;
        }

        public async Task<bool> CreatePassword(Guid userId, string password)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user is null) { return false; }

            user.Password = _hash.HashSHA256(password);

            return await _userService.UpdateUserAsync(user);
        }

        private async Task<User?> ValidateUser(string username, string password)
        {
            return await _userService.GetUserByEmailPassAsync(username, password);
        }

        private string CreateToken(UserSegWeb usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome!),
                new Claim("CodUsu", usuario.CodUsu!),
                new Claim("Autorizacoes", System.Text.Json.JsonSerializer.Serialize(usuario.Autorizacoes)),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authServiceConfig.SecretKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(_authServiceConfig.TokenExpMinutes),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
