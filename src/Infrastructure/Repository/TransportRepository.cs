using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TransportRepository : GenericAsyncRepository<Transport>, ITransportRepository
    {
        public TransportRepository(BlacktieDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<Transport?> GetByIdWithIncludeAsync(Guid id)
        {
            return await DbSet
                                    .Include(e => e.Variations)
                                    .AsNoTracking()
                                    .FirstAsync(x => x.Id == id);
        }

        public async Task<PagedList<Transport>?> GetFilteredAsync(TransportFilter filter)
        {
            IQueryable<Transport> query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(m => EF.Functions.Like(m.Name!.ToLower(), $"%{filter.Name.ToLower()}%"));
            }

            if(filter.TotalPassengers.HasValue)
            {
                query = query.Where(m => m.Variations!.Count(v => v.TotalPassengers >= filter.TotalPassengers && v.TotalBigBags >= filter.TotalBigBags && v.TotalSmallBags >= filter.TotalSmallBags ) > 0);
            }


            int count = await query.CountAsync();

            List<Transport> items = await query
                .Include(e => e.Variations)
                .OrderBy(m => m.Name)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return new PagedList<Transport>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
