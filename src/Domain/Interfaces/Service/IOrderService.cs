using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(Order order, Guid userId);
        Task<bool> UpdateAsync(Order order);
        Task<bool> DeleteAsync(Guid id);
        Task<PagedList<Order>?> GetFilteredAsync(OrderFilter filter);
        Task<Order?> GetByIdAsync(Guid id);
    }
}
