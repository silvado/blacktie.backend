using Domain.Exceptions;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Service;
using Domain.Interfaces.ServiceAgent;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    [ExcludeFromCodeCoverage]
    public class SistemaService : ISistemaService
    {
        private readonly IUnitOfWork _uow;
        private readonly ISegServiceAgent _segServiceAgent;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserClaimsHelper _userClaim;
        private readonly IHashHelper _hash;

        public SistemaService(IUnitOfWork uow, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ISegServiceAgent segServiceAgent, IUserClaimsHelper userClaim, IHashHelper hash)
        {
            _uow = uow;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _segServiceAgent = segServiceAgent;
            _userClaim = userClaim;
            _hash = hash;
        }

        public async Task<Sistema> CreateSistemaAsync(Sistema sistema)
        {

            var existe = await _uow.SistemaRepository.GetSistemaBySiglaAsync(sistema.SiglaSistema!);

            var sistemasUsuario = await _segServiceAgent.GetSistemaByUsuario(_userClaim.GetUserCodUsu()!);


            if (sistemasUsuario!.Data is null || !sistemasUsuario.Data.Sistemas!.Exists(x => x.SiglaSistema == sistema.SiglaSistema))
            {
                throw new BlacktieNotAcceptableException($"Usuário sem permissão para criar / alterar as configurações do sistema {sistema.SiglaSistema} .");
            }

            if (existe is not null)
            {
                throw new BlacktieNotAcceptableException("Sistema já cadastrado.");
            }

            sistema.Username = sistema.SiglaSistema!.ToLower() + _configuration["EnvironmentSufix"]!;

            var password = GenerateSecret();

            sistema.Password = _hash.HashSHA256(password);

            var sistemaSalvo = await _uow.SistemaRepository.AddAndSaveAsync(sistema);

            sistemaSalvo.Password = password;

            return sistemaSalvo;
        }

        public async Task<Sistema> UpdateSistemaCredencialAsync(Sistema sistema)
        {
            var possuiPermissaoCompleta = UsuarioPossuiPermissaoEvento("API-CONSULTA-TODOS");

            var sistemasUsuario = await _segServiceAgent.GetSistemaByUsuario(_userClaim.GetUserCodUsu()!);


            if (!possuiPermissaoCompleta &&
                (sistemasUsuario!.Data?.Sistemas?.ToList().Exists(x => x.SiglaSistema == sistema.SiglaSistema) != true))
            {
                throw new BlacktieNotAcceptableException(
                    $"Usuário sem permissão para criar / alterar as configurações do sistema {sistema.SiglaSistema}."
                );
            }

            var sistemaAtual = await _uow.SistemaRepository.GetByIdAsync(sistema.Id);
            if (sistemaAtual == null)
            {
                throw new KeyNotFoundException($"Sistema não encontrado.");
            }

            sistema.PasswordExpirationInHours = await GetPasswordExpiration();

            SistemaCredencial sistemaCredencial = new SistemaCredencial()
            {
                SistemaId = sistemaAtual.Id,
                Password = sistemaAtual.Password,
                DataExpiracao = DateTime.Now.AddHours((double)sistema.PasswordExpirationInHours),
            };

            await _uow.SistemaCredencialRepository.AddAsync(sistemaCredencial);

            var password = GenerateSecret();

            sistema.Password = _hash.HashSHA256(password);

            await _uow.SistemaRepository.UpdateAsync(sistema);

            sistema.Password = password;
            return sistema;
        }

        public async Task<bool> UpdateSistemaAsync(Sistema sistema)
        {
            var possuiPermissaoCompleta = UsuarioPossuiPermissaoEvento("API-CONSULTA-TODOS");

            var sistemasUsuario = await _segServiceAgent.GetSistemaByUsuario(_userClaim.GetUserCodUsu()!);


            if (!possuiPermissaoCompleta &&
                (sistemasUsuario!.Data?.Sistemas?.ToList().Exists(x => x.SiglaSistema == sistema.SiglaSistema) != true))
            {
                throw new BlacktieNotAcceptableException(
                    $"Usuário sem permissão para criar / alterar as configurações do sistema {sistema.SiglaSistema}."
                );
            }


            await _uow.SistemaRepository.UpdateAsync(sistema);

            return true;
        }



        public async Task<bool> PublishSistemaAsync(Sistema sistema)
        {

            var sistemasUsuario = await _segServiceAgent.GetSistemaByUsuario(_userClaim.GetUserCodUsu()!);


            if (sistemasUsuario!.Data is null || !sistemasUsuario.Data.Sistemas!.Exists(x => x.SiglaSistema == sistema.SiglaSistema))
            {
                throw new BlacktieNotAcceptableException($"Usuário sem permissão para criar / alterar as configurações do sistema {sistema.SiglaSistema} .");
            }

            var sistemaAtual = await _uow.SistemaRepository.GetByIdNoTrackingAsync(sistema.Id);
            if (sistemaAtual == null)
            {
                throw new KeyNotFoundException($"Sistema não encontrado.");
            }

            sistema.Configuracao = sistema.ConfiguracaoPrevia;
            sistema.PublishedAt = DateTime.Now;
            sistema.PublishedByUserId = _userClaim.GetUserCodUsu();

            await _uow.SistemaRepository.PublishAsync(sistema);

            SistemaPublicacao publishOld = new SistemaPublicacao()
            {
                SistemaId = sistemaAtual.Id,
                Configuracao = sistemaAtual.Configuracao,
                PublishedAt = sistemaAtual.PublishedAt,
                PublishedByUserId = sistemaAtual.PublishedByUserId
            };

            await _uow.SistemaPublicacaoRepository.AddAndSaveAsync(publishOld);
            return true;
        }

        public async Task<bool> DeleteSistemaAsync(int id)
        {
            var podeExcluir = UsuarioPossuiPermissaoEvento("API-DELETE");

            var sistema = await _uow.SistemaRepository.GetByIdAsync(id);

            var sistemasUsuario = await _segServiceAgent.GetSistemaByUsuario(_userClaim.GetUserCodUsu()!);

            if (!podeExcluir && (sistemasUsuario!.Data is null || !sistemasUsuario.Data.Sistemas!.Exists(x => x.SiglaSistema == sistema!.SiglaSistema)))
            {
                throw new BlacktieNotAcceptableException($"Usuário sem permissão para excluir as configurações do sistema {sistema!.SiglaSistema} .");
            }

            await _uow.SistemaRepository.SoftDeleteAsync(id);

            return true;
        }
        public async Task<PagedList<Sistema>?> GetFilteredAsync(SistemaFilter filter)
        {

            var listaTodos = UsuarioPossuiPermissaoEvento("API-CONSULTA-TODOS");

            var result = await _uow.SistemaRepository.GetFilteredAsync(filter);

            if (result is null) return null;

            var mapped = result.Data.Adapt<List<Sistema>>();


            if (!listaTodos)
            {

                var sistemasResponse = await _segServiceAgent.GetSistemaByUsuario(_userClaim.GetUserCodUsu()!);

                if (sistemasResponse?.Data?.Sistemas != null)
                {

                    mapped = mapped
                        .Where(x => sistemasResponse.Data.Sistemas
                        .Exists(y => y.SiglaSistema == x.SiglaSistema))
                        .ToList();
                }
                else
                {
                    return null;
                }
            }


            return new PagedList<Sistema>(mapped, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<Sistema?> GetSistemaByIdAsync(int id)
        {
            var listaTodos = UsuarioPossuiPermissaoEvento("API-CONSULTA-TODOS");

            var result = await _uow.SistemaRepository.GetByIdAsync(id);

            if (result == null)
                throw new OrderNotFoundException();

            var sistemasUsuario = await _segServiceAgent.GetSistemaByUsuario(_userClaim.GetUserCodUsu()!);

            if (!listaTodos && (sistemasUsuario!.Data is null || !sistemasUsuario.Data.Sistemas!.Exists(x => x.SiglaSistema == result.SiglaSistema)))
            {
                throw new BlacktieNotAcceptableException($"Usuário sem permissão para excluir as configurações do sistema {result.SiglaSistema} .");
            }

            result.PasswordExpirationInHours = await GetPasswordExpiration();

            return result;
        }

        public async Task<Sistema?> GetSistemaBySiglaAsync()
        {
            var siglaSistema = _httpContextAccessor.HttpContext!.User.FindFirst("SiglaSistema")!.Value;

            var result = await _uow.SistemaRepository.GetSistemaBySiglaAsync(siglaSistema);

            if (result == null)
                return null;

            return result;
        }
        public async Task<Sistema?> GetSistemaByUserPassAsync(string username, string password)
        {
            var sistema = await _uow.SistemaRepository.GetSistemaByUserPassAsync(username, password);

            if (sistema == null)
            {
                var sistemaByUser = await _uow.SistemaRepository.GetSistemaByUserAsync(username);

                if (sistemaByUser != null)
                {

                    var credenciais = (await _uow.SistemaCredencialRepository.GetByIdSistemaAsync(sistemaByUser.Id))?.ToList();

                    if (credenciais?.Exists(x => x.Password == password && x.DataExpiracao > DateTime.Now) == true)
                    {
                        sistema = sistemaByUser;
                    }
                }
            }

            return sistema;
        }


        public bool IsValidJson(string jsonString)
        {
            try
            {
                // Usa o JToken.Parse para verificar se é um JSON válido
                JToken.Parse(jsonString);
                return true;
            }
            catch (JsonReaderException)
            {
                // Se ocorrer um erro, não é um JSON válido
                return false;
            }
        }

        private async Task<Sistema?> GetSistemaBySiglaAsync(string siglaSistema)
        {

            var result = await _uow.SistemaRepository.GetSistemaBySiglaAsync(siglaSistema);

            if (result == null)
                return null;

            return result;
        }

        private static string GenerateSecret(int length = 20)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
            StringBuilder secret = new StringBuilder(length);
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[sizeof(uint)];

                for (int i = 0; i < length; i++)
                {
                    rng.GetBytes(randomBytes);
                    uint randomValue = BitConverter.ToUInt32(randomBytes, 0);
                    secret.Append(validChars[(int)(randomValue % (uint)validChars.Length)]);
                }
            }
            return secret.ToString();
        }

        private bool UsuarioPossuiPermissaoEvento(string evento)
        {
            var autorizacoesUsuario = _userClaim.GetUserAutorizacoes();

            return autorizacoesUsuario!.Any(x => x.Janela == evento && x.IndAutorizado == "S");
        }

        private async Task<int> GetPasswordExpiration()
        {
            var sapiconfig = await GetSistemaBySiglaAsync("SAPICONFIG");

            if (sapiconfig != null && sapiconfig.Configuracao != null && IsValidJson(sapiconfig.Configuracao))
            {

                var json = JObject.Parse(sapiconfig.Configuracao!);

                return Convert.ToInt16(json["oldPasswordExpirationInHours"]);

            }
            else
            {
                return 12;
            }

        }

    }
}
