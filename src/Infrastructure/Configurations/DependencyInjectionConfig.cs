using Application.Configuration;
using Application.Helpers;
using Application.Services;
using Application.Services.SendEmail;
using Domain.Interfaces.Common;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Interfaces.ServiceAgent;
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Repository.Common;
using Infrastructure.ServiceAgent;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Infrastructure.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
        {
            AddDataBase(services, configuration);
            AddRepositories(services);
            AddServices(services);
            AddHelpers(services);
            AddServiceAgents(services);
            services.AddServices();
            return services;
        }

        private static void AddDataBase(IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = GetConnectionString(configuration);

            services.AddDbContext<BlacktieDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.EnableSensitiveDataLogging();
                options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });
        }

        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient(typeof(IGenericAsyncRepository<>), typeof(GenericAsyncRepository<>));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ISistemaRepository, SistemaRepository>();
            services.AddScoped<ISistemaCredencialRepository, SistemaCredencialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IControlRepository, ControlRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
            services.AddScoped<ITransportRepository, TransportRepository>();
            services.AddScoped<ITransportVariationRepository, TransportVariationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IFromToRepository, FromToRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddScoped<IProductPricingRepository, ProductPricingRepository>();
            services.AddScoped<IUnavailableDateRepository, UnavailableDateRepository>();
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ISistemaService, SistemaService>();
            services.AddScoped<ISistemaPublicacaoService, SistemaPublicacaoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<ITransportVariationService, TransportVariationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFromToService, FromToService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IProductPricingService, ProductPricingService>();
            services.AddScoped<IUnavailableDateService, UnavailableDateService>();
        }

        public static void AddHelpers(IServiceCollection services)
        {
            services.AddScoped<IUserClaimsHelper, UserClaimsHelper>();
            services.AddScoped<IHashHelper, HashHelper>();
            services.AddScoped<IControlNumberHelper, ControlNumberHelper>();
        }

        public static void AddServiceAgents(IServiceCollection services)
        {
            services.AddScoped<HttpAgentBase, HttpAgentExterno>();
            services.AddScoped<ISegServiceAgent, SegServiceAgent>();
        }

        private static string GetConnectionString(IConfigurationRoot configuration)
        {
            return configuration.GetConnectionString("ConnectionString")!;
        }
    }
}