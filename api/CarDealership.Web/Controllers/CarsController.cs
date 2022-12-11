using CarDealership.Core.Application.Features.Cars.Commands.CreateCar;
using CarDealership.Core.Application.Features.Cars.Queries.GetCars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers;

[ApiController]
public class CarsController : ControllerBase
{
    private readonly ISender _sender;

    public CarsController(ISender sender)
        => _sender = sender;

    [HttpPost("{tenant}/api/cars")]
    public async Task CreateCar([FromBody] CreateCarCommand command)
        => await _sender.Send(command);

    [HttpGet("{tenant}/api/cars/list")]
    public async Task<List<GetCarsResult>> GetCars()
        => await _sender.Send(new GetCarsQuery());
}