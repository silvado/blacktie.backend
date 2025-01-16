using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IUserRepository : IGenericAsyncRepository<User>
    {
        Task<User?> GetUserByEmailPassAsync(string username, string password);
        Task<User?> GetUserByEmailAsync(string email);
        Task<PagedList<User>?> GetFilteredAsync(UserFilter filter);

    }
}
