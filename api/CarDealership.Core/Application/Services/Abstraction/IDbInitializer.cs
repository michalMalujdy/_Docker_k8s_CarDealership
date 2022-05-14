using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarDealership.Core.Application.Services.Abstraction;

public interface IDbInitializer
{
    void ConfigureDb<T>(IServiceCollection services, IConfiguration configuration, ILogger<T> logger);
}