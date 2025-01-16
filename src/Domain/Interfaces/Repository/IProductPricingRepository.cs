using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IProductPricingRepository : IGenericAsyncRepository<ProductPricing>
    {
        Task<PagedList<ProductPricing>?> GetFilteredAsync(GenericFilter filter);
    }
}
