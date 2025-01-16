using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericAsyncRepository<User>, IUserRepository
    {
        public UserRepository(BlacktieDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User?> GetUserByEmailPassAsync(string email, string password)
        {

            return await DbSet                                    
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {

            return await DbSet
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<PagedList<User>?> GetFilteredAsync(UserFilter filter)
        {
            IQueryable<User> query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(m => EF.Functions.Like(m.Name!.ToLower(), $"%{filter.Name.ToLower()}%"));
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(m => EF.Functions.Like(m.Email!.ToLower(), $"%{filter.Email.ToLower()}%"));
            }

            int count = await query.CountAsync();

            List<User> items = await query
                .OrderBy(m => m.Name)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return new PagedList<User>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
