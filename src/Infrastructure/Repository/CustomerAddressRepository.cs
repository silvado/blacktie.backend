using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CustomerAddressRepository : GenericAsyncRepository<CustomerAddress>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(BlacktieDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<CustomerAddress>> GetByCustomerIdAsync(Guid id)
        {
            return await DbSet.Where(x => x.CustomerId == id).ToListAsync();
        }
    }
}
