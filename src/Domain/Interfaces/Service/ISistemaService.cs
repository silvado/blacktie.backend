using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ISistemaService
    {
        Task<Sistema?> GetSistemaByIdAsync(int id);
        Task<Sistema?> GetSistemaBySiglaAsync();
        Task<Sistema?> GetSistemaByUserPassAsync(string username, string password);
        Task<PagedList<Sistema>?> GetFilteredAsync(SistemaFilter filter);
        Task<Sistema> CreateSistemaAsync(Sistema sistema);
        Task<Sistema> UpdateSistemaCredencialAsync(Sistema sistema);
        Task<bool> UpdateSistemaAsync(Sistema sistema);
        Task<bool> PublishSistemaAsync(Sistema sistema);
        Task<bool> DeleteSistemaAsync(int id);
        bool IsValidJson(string jsonString);

    }
}
