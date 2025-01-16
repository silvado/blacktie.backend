using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<ResultWrapper<Customer>> UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
        Task<PagedList<Customer>?> GetFilteredAsync(CustomerFilter filter);
        Task<Customer?> GetByIdAsync(Guid id);        
    }
}
