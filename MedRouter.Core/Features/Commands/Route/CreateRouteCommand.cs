using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Route;

public class CreateRouteCommand : IRequest<Response<int>>
{
    public string Mail { get; set; }
    public int? HotelId { get; set; }
    public int? HospitalId { get; set; }
    public string Type { get; set; }
    public string RouteName { get; set; }
}

public class CreateRouteCommandHandler : IRequestHandler< CreateRouteCommand ,Response<int>>
{
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public CreateRouteCommandHandler(IRouteRepository routeRepository, IMapper mapper)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        var route = _mapper.Map<Entities.Route>(request);
        await _routeRepository.CreateAsync(route);
        return new Response<int>(route.Id);
    }
}