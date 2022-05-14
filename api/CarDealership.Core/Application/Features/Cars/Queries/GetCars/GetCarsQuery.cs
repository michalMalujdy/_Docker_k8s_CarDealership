using MediatR;

namespace CarDealership.Core.Application.Features.Cars.Queries.GetCars;

public class GetCarsQuery : IRequest<List<GetCarsResult>> { }