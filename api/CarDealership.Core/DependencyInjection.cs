using System.Reflection;
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
        using var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetRequiredService<ILogger<Db>>();

        DbInitializer.ConfigureDb(services, configuration, logger);

        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}