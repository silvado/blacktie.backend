using Domain.Filters;
using Domain.Helpers;
using Domain.Models;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UnavailableDateRepository : GenericAsyncRepository<UnavailableDate>, IUnavailableDateRepository
    {
        public UnavailableDateRepository(BlacktieDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<PagedList<UnavailableDate>?> GetFilteredAsync(UnavailableDateFilter filter)
        {
            IQueryable<UnavailableDate> query = DbSet
           .AsQueryable();

            query = query.Where(m => m.IsDeleted == false);

            if (filter.Year.HasValue)
            {
                query = query.Where(m => m.Year == filter.Year);
            }
            if (filter.StartAt.HasValue)
            {
                query = query.Where(m => m.StartAt == filter.StartAt.Value);
            }
            if (filter.EndAt.HasValue)
            {
                query = query.Where(m => m.EndAt == filter.EndAt.Value);
            }

            int count = await query.CountAsync();

            List<UnavailableDate> items = await query
                .OrderBy(m => m.StartAt)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedList<UnavailableDate>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
