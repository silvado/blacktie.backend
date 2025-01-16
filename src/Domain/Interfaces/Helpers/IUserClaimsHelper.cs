using Domain.Entities.Authentication.Common;
using Domain.Models;

namespace Domain.Interfaces.Helpers
{
    public interface IUserClaimsHelper
    {
        string? GetUserName();
        string? GetUserCodUsu();
        string? GetUserMatricula();
        string? GetUserIdFunc();
        string? GetUserIp();
        IList<EstruturaAutorizacao>? GetUserAutorizacoes();
        UserSegWeb? GetUserFromClaims();
    }
}
