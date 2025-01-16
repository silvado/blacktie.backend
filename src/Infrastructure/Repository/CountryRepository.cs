using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CountryRepository : GenericAsyncRepository<Country>, ICountryRepository
    {
        public CountryRepository(BlacktieDbContext dbContext) : base(dbContext)
        { }
        public async Task<PagedList<Country>?> GetFilteredAsync(CountryFilter filter)
        {
            IQueryable<Country> query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(m => EF.Functions.Like(m.Name!.ToUpper(), $"%{filter.Name.ToUpper()}%"));
            }

            int count = await query.CountAsync();

            List<Country> items = await query
                .OrderBy(m => m.Id)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return new PagedList<Country>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
