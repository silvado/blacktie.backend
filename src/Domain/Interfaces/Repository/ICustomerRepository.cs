using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IGenericAsyncRepository<Customer>
    {        
        Task<Customer?> GetCustomerByEmailAsync(string email);
        Task<PagedList<Customer>?> GetFilteredAsync(CustomerFilter filter);
        Task<Customer?> GetByIdWithIncludeAsync(Guid id);
    }
}
