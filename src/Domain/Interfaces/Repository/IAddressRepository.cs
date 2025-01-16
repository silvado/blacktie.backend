using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IAddressRepository : IGenericAsyncRepository<Address>
    {
        Task<PagedList<Address>?> GetFilteredAsync(AddressFilter filter);
    }
}
