using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PaymentTypeRepository : GenericAsyncRepository<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(BlacktieDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<PagedList<PaymentType>?> GetFilteredAsync(GenericFilter filter)
        {
            IQueryable<PaymentType> query = DbSet
           .AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(m => EF.Functions.Like(m.Name!.ToLower(), $"%{filter.Name.ToLower()}%"));
            }

            int count = await query.CountAsync();

            List<PaymentType> items = await query
                .OrderBy(m => m.Name)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedList<PaymentType>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
