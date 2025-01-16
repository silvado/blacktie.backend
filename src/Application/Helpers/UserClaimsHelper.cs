using Domain.Entities.Authentication.Common;
using Domain.Interfaces.Helpers;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Helpers
{
    public class UserClaimsHelper : IUserClaimsHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserClaimsHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("NomeUsu")?.Value ?? string.Empty;
        }

        public string? GetUserCodUsu()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("CodUsu")?.Value ?? string.Empty;
        }

        public string? GetUserMatricula()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("MatriculaUsu")?.Value ?? string.Empty;
        }

        public string? GetUserIdFunc()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("IdFunc")?.Value ?? string.Empty;
        }

        public string GetUserIp()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("IpUsu")?.Value ?? string.Empty;
        }

        public IList<EstruturaAutorizacao>? GetUserAutorizacoes()
        {
            var autorizacoesJson = _httpContextAccessor.HttpContext?.User.FindFirst("Autorizacoes")?.Value;
            return string.IsNullOrEmpty(autorizacoesJson)
                ? new List<EstruturaAutorizacao>()
                : System.Text.Json.JsonSerializer.Deserialize<IList<EstruturaAutorizacao>>(autorizacoesJson)!;
        }

        public UserSegWeb? GetUserFromClaims()
        {

            return new UserSegWeb
            {
                CodUsu = GetUserCodUsu(),
                Nome = GetUserName(),
                Matricula = GetUserMatricula(),
                IDFunc = int.TryParse(GetUserIdFunc(), out var idFunc) ? idFunc : (int?)null,
                NomeMaquina = GetUserIp(),
                Autorizacoes = GetUserAutorizacoes()

            };
        }
    }
}
