using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Repository
{
    public class OrderRepository : GenericAsyncRepository<Order>, IOrderRepository
    {
        public OrderRepository(BlacktieDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order?> GetByIdWithIncludeAsync(Guid id)
        {
            return await DbSet
                                    .Include(e => e.Product).ThenInclude(v => v.Transport)
                                    .Include(e => e.Product).ThenInclude(v => v.From)
                                    .Include(e => e.Product).ThenInclude(v => v.To)
                                    .Include(e => e.Customer).ThenInclude(c => c.CustomerAddresses).ThenInclude(a=> a.Address)
                                    .AsNoTracking()
                                    .FirstAsync(x => x.Id == id);
        }

        public async Task<PagedList<Order>?> GetFilteredAsync(OrderFilter filter)
        {
            IQueryable<Order> query = DbSet
           .Include(e => e.Product).ThenInclude(v => v.Transport)
           .Include(e => e.Customer)
           .AsQueryable();

            if (filter.IsDeleted.HasValue)
            {
                query = query.Where(m => m.IsDeleted == filter.IsDeleted);
            }

            if (filter.ProductId.HasValue)
            {
                query = query.Where(m => m.ProductId == filter.ProductId);
            }
            if (filter.CustomerId.HasValue)
            {
                query = query.Where(m => m.CustomerId == filter.CustomerId);
            }                       

            int count = await query.CountAsync();

            List<Order> items = await query
                .OrderBy(m => m.Date)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedList<Order>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
