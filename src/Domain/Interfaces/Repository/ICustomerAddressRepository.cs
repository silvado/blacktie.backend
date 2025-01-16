using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface ICustomerAddressRepository : IGenericAsyncRepository<CustomerAddress>
    {
        Task<List<CustomerAddress>> GetByCustomerIdAsync(Guid id);
    }
}
