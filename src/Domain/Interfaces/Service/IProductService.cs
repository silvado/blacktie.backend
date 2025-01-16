using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Guid id);
        Task<PagedList<Product>?> GetFilteredAsync(ProductFilter filter);
        Task<Product?> GetByIdAsync(Guid id);
    }
}
