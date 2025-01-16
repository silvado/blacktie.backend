using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IProductPricingService
    {
        Task<ProductPricing> CreateAsync(ProductPricing productpricing);
        Task<bool> UpdateAsync(ProductPricing productpricing);
        Task<bool> DeleteAsync(int id);
        Task<ProductPricing?> GetByIdAsync(int id);
    }
}
