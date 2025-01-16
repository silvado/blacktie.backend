using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductPricingRepository : GenericAsyncRepository<ProductPricing>, IProductPricingRepository
    {
        public ProductPricingRepository(BlacktieDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<PagedList<ProductPricing>?> GetFilteredAsync(GenericFilter filter)
        {
            IQueryable<ProductPricing> query = DbSet
           .AsQueryable();           

            int count = await query.CountAsync();

            List<ProductPricing> items = await query
                .OrderBy(m => m.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedList<ProductPricing>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
