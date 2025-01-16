using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ControlRepository : GenericAsyncRepository<Control>, IControlRepository
    {
        public ControlRepository(BlacktieDbContext dbContext) : base(dbContext)
        { }
        public async Task<bool> ValidateControl(Guid userId, string control)
        {

            var result = await DbSet
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.UserId == userId && x.ControlNumber == control);

            if (result == null) return false;

            if (result.ExpireAt >= DateTime.Now) return true;
            
            return false;
        }
    }
}
