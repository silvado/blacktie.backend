using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ICountryService
    {
        Task<PagedList<Country>?> GetFilteredAsync(CountryFilter filter);
    }
}
