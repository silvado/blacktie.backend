using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{    
    public interface IUnavailableDateRepository : IGenericAsyncRepository<UnavailableDate>
    {
        Task<PagedList<UnavailableDate>?> GetFilteredAsync(UnavailableDateFilter filter);
    }
}
