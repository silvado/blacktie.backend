using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IProductRepository : IGenericAsyncRepository<Product>
    {        
        Task<PagedList<Product>?> GetFilteredAsync(ProductFilter filter);
        Task<Product?> GetByIdWithIncludeAsync(Guid id);
    }
}
