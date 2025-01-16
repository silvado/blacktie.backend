using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public partial class BlacktieDbContext
    {        
        public virtual DbSet<Audit>? Audits { get; set; }
    }
}
