using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{

    public class SistemaPublicacaoRepository : GenericAsyncRepository<SistemaPublicacao>, ISistemaPublicacaoRepository

    {
        public SistemaPublicacaoRepository(BlacktieDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PagedList<SistemaPublicacao>?> GetSistemaPublicacaoAsync(SistemaFilter filter)
        {
            IQueryable<SistemaPublicacao> query = DbSet.AsQueryable();

            //query = query.Where(m => m.SistemaId == filter.Id);

            int count = await query.CountAsync();

            List<SistemaPublicacao> items = await query
                .OrderByDescending(m => m.CreatedAt)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return new PagedList<SistemaPublicacao>(items, count, filter.PageNumber, filter.PageSize);

        }

        public async Task<PagedList<SistemaPublicacao>?> GetFilteredAsync(SistemaPublicacaoFilter filter)
        {
            IQueryable<SistemaPublicacao> query = DbSet.AsQueryable()
                                                       .Where(s => !s.IsDeleted)
                                                       .Include(s => s.Sistema);

            if (!string.IsNullOrEmpty(filter.NomeSistema))
            {
                query = query.Where(s => s.Sistema != null &&
                                         s.Sistema.NomeSistema.ToLowerInvariant().Contains(filter.NomeSistema.ToLowerInvariant()));
            }
            if (filter.IdSistema.HasValue)
            {
                query = query.Where(s => s.SistemaId == filter.IdSistema);
            }

            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
            filter.PageNumber = filter.PageNumber <= 0 ? 1 : filter.PageNumber;

            int count = await query.CountAsync();
            var items = await query.OrderBy(s => s.Sistema!.NomeSistema)
                                   .Skip((filter.PageNumber - 1) * filter.PageSize)
                                   .Take(filter.PageSize)
                                   .ToListAsync();

            return new PagedList<SistemaPublicacao>(items, count, filter.PageNumber, filter.PageSize);
        }


    }
}
