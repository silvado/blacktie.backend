using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AddressRepository : GenericAsyncRepository<Address>, IAddressRepository
    {
        public AddressRepository(BlacktieDbContext dbContext) : base(dbContext)
        {}        
        public async Task<PagedList<Address>?> GetFilteredAsync(AddressFilter filter)
        {
            IQueryable<Address> query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Street))
            {
                query = query.Where(m => EF.Functions.Like(m.Street!.ToLower(), $"%{filter.Street.ToLower()}%"));
            }           

            int count = await query.CountAsync();

            List<Address> items = await query
                .OrderBy(m => m.Street)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return new PagedList<Address>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
