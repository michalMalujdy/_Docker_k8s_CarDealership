namespace CarDealership.Core.Domain;

public class Car
{
    public Guid Id { get; set; }
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string RegistrationNumber { get; set; } = null!;
}