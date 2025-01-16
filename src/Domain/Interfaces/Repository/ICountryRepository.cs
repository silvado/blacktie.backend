using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface ICountryRepository : IGenericAsyncRepository<Country>
    {
        Task<PagedList<Country>?> GetFilteredAsync(CountryFilter filter);
    }
}
