using CarDealership.Core.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Core.Application.Cars.Queries.GetCars;

public class GetCarsHandler : IRequestHandler<GetCarsQuery, List<GetCarsResult>>
{
    private readonly Db _db;

    public GetCarsHandler(Db db)
        => _db = db;

    public async Task<List<GetCarsResult>> Handle(GetCarsQuery query, CancellationToken ct)
        => await _db.Cars
            .Select(x => new GetCarsResult
            {
                Make = x.Make,
                Model = x.Model,
                RegistrationNumber = x.RegistrationNumber
            })
            .ToListAsync(ct);
}