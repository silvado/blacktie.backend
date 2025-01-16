using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ISistemaPublicacaoService
    {
        Task<PagedList<SistemaPublicacao>?> GetFilteredAsync(SistemaPublicacaoFilter filter);
        Task<SistemaPublicacao?> GetByIdAsync(int id);
    }
}
