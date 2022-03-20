using MediatR;

namespace CarDealership.Core.Application.Cars.Commands.CreateCar;

public class CreateCarCommand : IRequest
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
}