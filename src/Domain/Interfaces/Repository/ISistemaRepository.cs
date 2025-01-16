using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface ISistemaRepository : IGenericAsyncRepository<Sistema>
    {
        Task<PagedList<Sistema>?> GetFilteredAsync(SistemaFilter filter);
        Task<Sistema?> GetSistemaBySiglaAsync(string siglaSistema);
        Task<Sistema?> GetSistemaByUserPassAsync(string username, string password);
        Task<Sistema?> GetSistemaByUserAsync(string username);
    }
}
