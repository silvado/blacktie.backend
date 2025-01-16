using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TransportVariationRepository : GenericAsyncRepository<TransportVariation>, ITransportVariationRepository
    {
        public TransportVariationRepository(BlacktieDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<TransportVariation?> GetByIdWithIncludeAsync(Guid id)
        {
            return await DbSet
                                    .Include(e => e.Transport)
                                    .AsNoTracking()
                                    .FirstAsync(x => x.TransportId == id);
        }

        public async Task<PagedList<TransportVariation>?> GetFilteredAsync(TransportFilter filter)
        {
            IQueryable<TransportVariation> query = DbSet.AsQueryable();

            int count = await query.CountAsync();

            List<TransportVariation> items = await query
                .Include(e => e.Transport)
                .OrderBy(m => m.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return new PagedList<TransportVariation>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
