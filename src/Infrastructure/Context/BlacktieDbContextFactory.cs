using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class BlacktieDbContextFactory : IDesignTimeDbContextFactory<BlacktieDbContext>
    {
        public BlacktieDbContext CreateDbContext(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "src", "API");
            var configuration = new ConfigurationBuilder()                
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BlacktieDbContext>();
            var connectionString = configuration.GetConnectionString("ConnectionString");

            optionsBuilder.UseNpgsql(connectionString!);

            return new BlacktieDbContext(optionsBuilder.Options);
        }
    }
}
