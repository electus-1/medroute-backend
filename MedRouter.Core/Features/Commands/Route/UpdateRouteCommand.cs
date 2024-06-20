using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Route;

public class UpdateRouteCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string Mail { get; set; }
    public int? HotelId { get; set; }
    public int? HospitalId { get; set; }
    public string Type { get; set; }
    public string RouteName { get; set; }
}

public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, Response<int>>
{
    private IMapper _mapper;
    private IRouteRepository _routeRepository;

    public UpdateRouteCommandHandler(IMapper mapper, IRouteRepository routeRepository)
    {
        _mapper = mapper;
        _routeRepository = routeRepository;
    }

    public async Task<Response<int>> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
    {
        var route = _mapper.Map<Entities.Route>(request);
        await _routeRepository.UpdateAsync(route);
        return new Response<int>(route.Id);
    }
}