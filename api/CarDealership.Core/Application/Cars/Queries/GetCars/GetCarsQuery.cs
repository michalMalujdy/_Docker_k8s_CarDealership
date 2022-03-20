using MediatR;

namespace CarDealership.Core.Application.Cars.Queries.GetCars;

public class GetCarsQuery : IRequest<List<GetCarsResult>> { }