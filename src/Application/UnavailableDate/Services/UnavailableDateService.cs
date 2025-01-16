using Domain.Filters;
using Domain.Helpers;
using Domain.Models;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;

namespace Application.Services
{
    public class UnavailableDateService : IUnavailableDateService
    {
        private readonly IUnavailableDateRepository _repository;


        public UnavailableDateService(IUnavailableDateRepository repository)
        {
            _repository = repository;
        }


        public async Task<UnavailableDate> CreateAsync(UnavailableDate unavailabledate)
        {


            var newUnavailableDate = await _repository.AddAndSaveAsync(unavailabledate);

            return newUnavailableDate;
        }

        public async Task<bool> UpdateAsync(UnavailableDate unavailabledate)
        {

            await _repository.UpdateAsync(unavailabledate);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            await _repository.SoftDeleteAsync(id);

            return true;
        }

        public async Task<PagedList<UnavailableDate>?> GetFilteredAsync(UnavailableDateFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;

            return new PagedList<UnavailableDate>(result.Data, result.TotalCount, filter.PageNumber, filter.PageSize);
        }


        public async Task<UnavailableDate?> GetByIdAsync(int id)
        {

            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;


            return result;
        }

    }
}
