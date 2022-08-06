using CarDealership.Core.Application.Services.Abstraction;
using Microsoft.Extensions.Configuration;

namespace CarDealership.Core.Application.Services.Implementation;

public class CurrentTenantProvider : ICurrentTenantProvider
{
    private const string VariableName = "CAR_DEALERSHIP_CURRENT_TENANT";

    public string GetCurrentTenant()
    {
        var currentTenant = Environment.GetEnvironmentVariable(VariableName);

        if (string.IsNullOrWhiteSpace(currentTenant))
        {
            throw new Exception("Current tenant is empty");
        }

        return currentTenant.ToLowerInvariant();
    }
}