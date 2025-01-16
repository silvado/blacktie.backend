using Domain.Exceptions;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;


        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task<Product> CreateAsync(Product product)
        {

            ProductFilter filter = new ProductFilter()
            {
                FromId = product.FromId,
                ToId = product.ToId,
                TransportId = product.TransportId,
            };

            var products = await _repository.GetFilteredAsync(filter);

            if (products != null && products.Data.Any())
            {
                throw new BlacktieNotAcceptableException("Já existe um produto com as mesmas características cadastrado.");
            }


            var newProduct = await _repository.AddAndSaveAsync(product);

            return newProduct;
        }

        public async Task<bool> UpdateAsync(Product product)
        {

            await _repository.UpdateAsync(product);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _repository.SoftDeleteGuidAsync(id);

            return true;
        }

        public async Task<PagedList<Product>?> GetFilteredAsync(ProductFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;

            return new PagedList<Product>(result.Data, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {

            var result = await _repository.GetByIdWithIncludeAsync(id);

            if (result == null)
                return null;


            return result;
        }
    }
}
