using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CustomerRepository : GenericAsyncRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BlacktieDbContext dbContext) : base(dbContext)
        {

        }        

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {

            return await DbSet
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Customer?> GetByIdWithIncludeAsync(Guid id)
        {
            return await DbSet
                                    .Include(e => e.CustomerAddresses).ThenInclude(e => e.Address)                                    
                                    .AsNoTracking()
                                    .FirstAsync(x => x.Id == id);
        }

        public async Task<PagedList<Customer>?> GetFilteredAsync(CustomerFilter filter)
        {
            IQueryable<Customer> query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(m => EF.Functions.Like(m.Name!.ToLower(), $"%{filter.Name.ToLower()}%"));
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(m => EF.Functions.Like(m.Email!.ToLower(), $"%{filter.Email.ToLower()}%"));
            }

            int count = await query.CountAsync();

            List<Customer> items = await query
                .Include(e => e.CustomerAddresses).ThenInclude(e => e.Address)
                .OrderBy(m => m.Name)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return new PagedList<Customer>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
