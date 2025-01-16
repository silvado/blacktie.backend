using Domain.Entities.Authentication.Common;
using Domain.Models;

namespace Domain.Interfaces.Authentication
{
    public interface IAuthService
    {
        public Task<HttpResponseMessage> GetUsuario(SegWebCredential segwebCredencial);
        public Task<UserSegWeb?> GetUserSession(string sessionId, string codigoOrganizacao);
        public User? BasicAuthenticate(string email, string password);
        public Task<bool> ValidateControl(Guid userId, string control);
        public Task<bool> CreateControl(string email);
        public Task<bool> CreatePassword(Guid userId, string password);
    }
}
