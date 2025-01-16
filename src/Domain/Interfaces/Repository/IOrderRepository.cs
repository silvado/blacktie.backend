using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IOrderRepository : IGenericAsyncRepository<Order>
    {
        Task<PagedList<Order>?> GetFilteredAsync(OrderFilter filter);
        Task<Order?> GetByIdWithIncludeAsync(Guid id);
    }
}
