using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;

        public CountryService(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<Country>?> GetFilteredAsync(CountryFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;

            var mapped = result.Data.Adapt<List<Country>>();



            return new PagedList<Country>(mapped, result.TotalCount, filter.PageNumber, filter.PageSize);
        }
    }
}
