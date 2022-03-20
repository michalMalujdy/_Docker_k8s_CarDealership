using CarDealership.Core.Domain;
using CarDealership.Core.Persistence;
using MediatR;

namespace CarDealership.Core.Application.Cars.Commands.CreateCar;

public class CreateCarHandler : IRequestHandler<CreateCarCommand>
{
    private readonly Db _db;

    public CreateCarHandler(Db db)
        => _db = db;

    public async Task<Unit> Handle(CreateCarCommand command, CancellationToken ct)
    {
        var car = new Car
        {
            Make = command.Make,
            Model = command.Model,
            RegistrationNumber = command.RegistrationNumber
        };

        _db.Cars.Add(car);
        await _db.SaveChangesAsync(ct);

        return Unit.Value;
    }
}