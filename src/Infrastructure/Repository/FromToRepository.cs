using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Repository
{
    public class FromToRepository : GenericAsyncRepository<FromTo>, IFromToRepository
    {
        public FromToRepository(BlacktieDbContext dbContext) : base(dbContext)
        {
        }       
        public async Task<PagedList<FromTo>?> GetFilteredAsync(GenericFilter filter)
        {
            IQueryable<FromTo> query = DbSet           
           .AsQueryable();           
                

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(m => EF.Functions.Like(m.Name!.ToLower(), $"%{filter.Name.ToLower()}%"));
            }

            int count = await query.CountAsync();

            List<FromTo> items = await query
                .OrderBy(m => m.Name)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedList<FromTo>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
