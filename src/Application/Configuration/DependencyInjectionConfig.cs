using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Application.Services.Authentication;
using Domain.Interfaces.Authentication;
using System.Diagnostics.CodeAnalysis;

namespace Application.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            AddAuthServices(services);
            ValidateConfigurationService(services);
        }

        private static void AddAuthServices(IServiceCollection services)
        {
            services.AddOptions<AuthServiceConfig>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("AuthService").Bind(settings);
                });

            services.AddScoped<IAuthService, AuthService>();
        }

        private static void ValidateConfigurationService(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var authServiceConfig = provider.GetService<IOptions<AuthServiceConfig>>();

            if (authServiceConfig?.Value == null)
                throw new ArgumentException($"\"{nameof(authServiceConfig)}\" Not Found");

            if (string.IsNullOrWhiteSpace(authServiceConfig.Value.UrlPermissao))
                throw new ArgumentException("Configuration not found", "UrlPermissao");

            if (string.IsNullOrWhiteSpace(authServiceConfig.Value.SecretKey))
                throw new ArgumentException("Configuration not found", "SecretKey");
        }

    }
}
