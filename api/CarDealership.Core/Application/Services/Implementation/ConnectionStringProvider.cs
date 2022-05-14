using CarDealership.Core.Application.Services.Abstraction;
using Microsoft.Extensions.Configuration;

namespace CarDealership.Core.Application.Services.Implementation;

public class ConnectionStringProvider : IConnectionStringProvider
{
    private readonly IConfiguration _configuration;
    private readonly ICurrentTenantProvider _currentTenantProvider;

    public ConnectionStringProvider(IConfiguration configuration, ICurrentTenantProvider currentTenantProvider)
    {
        _configuration = configuration;
        _currentTenantProvider = currentTenantProvider;
    }

    public string GetConnectionString()
    {
        var configConnectionString = _configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(configConnectionString))
        {
            throw new Exception("Connection string from configuration is empty");
        }

        return configConnectionString.Replace("{tenant}", _currentTenantProvider.GetCurrentTenant());
    }
}