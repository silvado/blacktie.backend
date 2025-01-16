using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Infrastructure.Health
{
    public class DataBaseHealthCheck : IHealthCheck
    {
        private readonly BlacktieDbContext _dbContext;

        public DataBaseHealthCheck(BlacktieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync("SELECT 1", cancellationToken);
                
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {            
                return HealthCheckResult.Unhealthy(exception: ex);
            }
        }
    }
}
