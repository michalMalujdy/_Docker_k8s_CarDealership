using System.Reflection;
using CarDealership.Core.Application.Services;
using CarDealership.Core.Application.Services.Abstraction;
using CarDealership.Core.Application.Services.Implementation;
using CarDealership.Core.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarDealership.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentTenantProvider, CurrentTenantProvider>();
        services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();
        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddMediatR(Assembly.GetExecutingAssembly());

        using var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetRequiredService<ILogger<Db>>();
        var dbInitializer = serviceProvider.GetRequiredService<IDbInitializer>();

        dbInitializer.ConfigureDb(services, configuration, logger);

        return services;
    }
}