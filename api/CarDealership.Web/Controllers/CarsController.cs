using CarDealership.Core.Application.Cars.Commands.CreateCar;
using CarDealership.Core.Application.Cars.Queries.GetCars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private readonly ISender _sender;

    public CarsController(ISender sender)
        => _sender = sender;

    [HttpPost]
    public async Task CreateCar([FromBody] CreateCarCommand command)
        => await _sender.Send(command);

    [HttpGet("list")]
    public async Task<List<GetCarsResult>> GetCars()
        => await _sender.Send(new GetCarsQuery());
}