using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IAddressService
    {
        Task<Address> CreateAddressAsync(Address address);
        Task<bool> UpdateAddressAsync(Address address);
        Task<bool> DeleteAddressAsync(int id);
        Task<PagedList<Address>?> GetFilteredAsync(AddressFilter filter);
        Task<Address?> GetAddressByIdAsync(int id);


    }
}
