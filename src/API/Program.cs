using API.Configuration;
using Application.Behaviors;
using Application.Configuration;
using FluentValidation;
using HealthChecks.UI.Client;
using Infrastructure.Configurations;
using Infrastructure.Health;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WEB.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(configuration.GetSection("AuthService:SecretKey").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddApiConfig(configuration);

builder.Services.AddInfrastructure(configuration);

builder.Services.AddAuthorization();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserConfigPolicy", policy =>
        policy.RequireAuthenticatedUser().RequireClaim("RouteAccess", "sistema/config"));
});

builder.Services.AddSingleton(builder.Configuration);


builder.Services.AddHealthChecks()
    .AddCheck<DataBaseHealthCheck>("DB");

var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
builder.Services.AddMemoryCache();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddValidatorsFromAssembly(applicationAssembly);

builder.Services.ConfigureMappings();

var app = builder.Build();

app.MapHealthChecks("/api/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});


// Configure
app.UseApiConfig(app.Environment);

app.MapControllers();



await app.RunAsync();