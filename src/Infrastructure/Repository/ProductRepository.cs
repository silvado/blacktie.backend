using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductRepository : GenericAsyncRepository<Product>, IProductRepository
    {
        public ProductRepository(BlacktieDbContext dbContext) : base(dbContext)
        {
        }        

        public async Task<Product?> GetByIdWithIncludeAsync(Guid id)
        {
            return await DbSet
                                    .Include(e => e.Transport).ThenInclude(v=> v.Variations)
                                    .Include(e => e.From)
                                    .Include(e => e.To)
                                    .AsNoTracking()
                                    .FirstAsync(x => x.Id == id);
        }

        public async Task<PagedList<Product>?> GetFilteredAsync(ProductFilter filter)
        {
            IQueryable<Product> query = DbSet
           .Include(e => e.From)
           .Include(e => e.To)
           .Include(e => e.Transport).ThenInclude(e => e.Variations)           
           .AsQueryable();

            if (filter.IsDeleted.HasValue)
            {
                query = query.Where(m => m.IsDeleted == filter.IsDeleted);
            }

            if (filter.IsLocked.HasValue)
            {
                query = query.Where(m => m.IsLocked == filter.IsLocked);
            }
            if (filter.FromId.HasValue)
            {
                query = query.Where(m => m.FromId == filter.FromId);
            }
            if (filter.ToId.HasValue)
            {
                query = query.Where(m => m.ToId == filter.ToId);
            }
            if (filter.TransportId.HasValue)
            {
                query = query.Where(m => m.TransportId == filter.TransportId);
            }

            // Filtro nas variações do transporte
            if (filter.TotalSmallBags.HasValue || filter.TotalBigBags.HasValue || filter.TotalPassengers.HasValue)
            {
                query = query.Where(m =>
                    m.Transport.Variations.Any(v =>
                        (!filter.TotalSmallBags.HasValue || v.TotalSmallBags >= filter.TotalSmallBags.Value) &&
                        (!filter.TotalBigBags.HasValue || v.TotalBigBags >= filter.TotalBigBags.Value) &&
                        (!filter.TotalPassengers.HasValue || v.TotalPassengers >= filter.TotalPassengers.Value)
                    )
                );
            }

            int count = await query.CountAsync();

            List<Product> items = await query
                .OrderBy(m => m.Price)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedList<Product>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
