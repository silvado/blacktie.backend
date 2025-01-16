using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IFromToRepository : IGenericAsyncRepository<FromTo>
    {
        Task<PagedList<FromTo>?> GetFilteredAsync(GenericFilter filter);        
    }
}
