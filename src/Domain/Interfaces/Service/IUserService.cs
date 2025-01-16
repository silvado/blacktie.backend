using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> UpdateUserCredentialAsync(User user);
        Task<User?> GetUserByEmailPassAsync(string email, string password);
        Task<PagedList<User>?> GetFilteredAsync(UserFilter filter);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
