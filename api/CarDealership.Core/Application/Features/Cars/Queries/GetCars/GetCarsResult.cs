namespace CarDealership.Core.Application.Features.Cars.Queries.GetCars;

public class GetCarsResult
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
}