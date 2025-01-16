using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            return await _repository.AddAndSaveAsync(address);
        }

        public async Task<bool> UpdateAddressAsync(Address address)
        {
            await _repository.UpdateAsync(address);

            return true;
        }
         public async Task<bool> DeleteAddressAsync(int id)
        {
            await _repository.SoftDeleteAsync(id);

            return true;
        }


        public async Task<PagedList<Address>?> GetFilteredAsync(AddressFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;

            var mapped = result.Data.Adapt<List<Address>>();

            return new PagedList<Address>(mapped, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<Address?> GetAddressByIdAsync(int id)
        {

            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;


            return result;
        }
    }
}
