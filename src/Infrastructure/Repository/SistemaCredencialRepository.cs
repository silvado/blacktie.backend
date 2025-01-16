using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class SistemaCredencialRepository : GenericAsyncRepository<SistemaCredencial>, ISistemaCredencialRepository

    {
        public SistemaCredencialRepository(BlacktieDbContext dbContext) : base(dbContext)
        { }

        public async Task<List<SistemaCredencial>?> GetByIdSistemaAsync(int sistemaId)
        {
            IQueryable<SistemaCredencial> query = DbSet.AsQueryable();

            query = query.Where(m => !m.IsDeleted  && m.SistemaId == sistemaId);

            return await query
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();

        }
    }
}
