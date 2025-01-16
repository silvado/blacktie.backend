using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ITransportService
    {
        Task<Transport> CreateAsync(Transport transport);
        Task<bool> UpdateAsync(Transport transport);
        Task<bool> DeleteAsync(Guid id);
        Task<PagedList<Transport>?> GetFilteredAsync(TransportFilter filter);
        Task<Transport?> GetByIdAsync(Guid id);
    }
}
