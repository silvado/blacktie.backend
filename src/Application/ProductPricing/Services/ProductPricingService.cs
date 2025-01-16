using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;

namespace Application.Services
{
    public class ProductPricingService : IProductPricingService
    {
        private readonly IProductPricingRepository _repository;


        public ProductPricingService(IProductPricingRepository repository)
        {
            _repository = repository;
        }


        public async Task<ProductPricing> CreateAsync(ProductPricing productpricing)
        {


            var newProductPricing = await _repository.AddAndSaveAsync(productpricing);

            return newProductPricing;
        }

        public async Task<bool> UpdateAsync(ProductPricing productpricing)
        {

            await _repository.UpdateAsync(productpricing);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            await _repository.SoftDeleteAsync(id);

            return true;
        }

        public async Task<ProductPricing?> GetByIdAsync(int id)
        {

            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;


            return result;
        }

    }
}
