namespace CarDealership.Core.Application.Services.Abstraction;

public interface ICurrentTenantProvider
{
    string GetCurrentTenant();
}