using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface ITransportRepository : IGenericAsyncRepository<Transport>
    {        
        Task<PagedList<Transport>?> GetFilteredAsync(TransportFilter filter);
        Task<Transport?> GetByIdWithIncludeAsync(Guid id);
    }
}
