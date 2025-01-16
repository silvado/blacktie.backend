
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface ISistemaPublicacaoRepository : IGenericAsyncRepository<SistemaPublicacao>
    {
        Task<PagedList<SistemaPublicacao>?> GetFilteredAsync(SistemaPublicacaoFilter filter);
        Task<PagedList<SistemaPublicacao>?> GetSistemaPublicacaoAsync(SistemaFilter filter);
    }
}
