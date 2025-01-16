using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class SistemaRepository : GenericAsyncRepository<Sistema>, ISistemaRepository
    {
        public SistemaRepository(BlacktieDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<Sistema?> GetSistemaBySiglaAsync(string siglaSistema)
        {
            return await DbSet
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.SiglaSistema == siglaSistema);
        }

        public async Task<Sistema?> GetSistemaByUserPassAsync(string username, string password)
        {

            return await DbSet
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<Sistema?> GetSistemaByUserAsync(string username)
        {

            return await DbSet
                                    .AsNoTracking()
                                    .FirstAsync(x => x.Username == username);
        }

        public async Task<PagedList<Sistema>?> GetFilteredAsync(SistemaFilter filter)
        {
            IQueryable<Sistema> query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filter.NomeSistema))
            {
                query = query.Where(m => EF.Functions.Like(m.NomeSistema!.ToLower(), $"%{filter.NomeSistema.ToLower()}%"));
            }

            if (!string.IsNullOrEmpty(filter.SiglaSistema))
            {
                query = query.Where(m => EF.Functions.Like(m.SiglaSistema!.ToLower(), $"%{filter.SiglaSistema.ToLower()}%"));
            }

            int count = await query.CountAsync();

            List<Sistema> items = await query
                .OrderBy(m => m.NomeSistema)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return new PagedList<Sistema>(items, count, filter.PageNumber, filter.PageSize);
        }
    }
}
