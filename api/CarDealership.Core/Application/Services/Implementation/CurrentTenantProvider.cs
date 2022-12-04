using CarDealership.Core.Application.Services.Abstraction;
using Microsoft.Extensions.Configuration;

namespace CarDealership.Core.Application.Services.Implementation;

public class CurrentTenantProvider : ICurrentTenantProvider
{
    private const string VariableName = "CAR_DEALERSHIP_CURRENT_TENANT";
    private const string DefaultTenant = "development";

    public string GetCurrentTenant()
    {
        var currentTenant = Environment.GetEnvironmentVariable(VariableName);

        return string.IsNullOrWhiteSpace(currentTenant)
            ? DefaultTenant
            : currentTenant.ToLowerInvariant();
    }
}