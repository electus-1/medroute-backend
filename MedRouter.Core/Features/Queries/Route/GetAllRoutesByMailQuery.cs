using System.Collections;
using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Route;

public class GetAllRoutesByMailQuery : IRequest<Response<IEnumerable<GetRouteViewModel>>> 
{
    public string Mail { get; set; }
}

public class GetAllRoutesByMailQueryHandler : IRequestHandler<GetAllRoutesByMailQuery, Response<IEnumerable<GetRouteViewModel>>>
{
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public GetAllRoutesByMailQueryHandler(IRouteRepository routeRepository, IMapper mapper)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetRouteViewModel>>> Handle(GetAllRoutesByMailQuery request, CancellationToken cancellationToken)
    {
        var routes = await _routeRepository.GetByMail(request.Mail, cancellationToken);
        var routeViewModels = _mapper.Map<IEnumerable<GetRouteViewModel>>(routes);
        return new Response<IEnumerable<GetRouteViewModel>>(routeViewModels);
    }
}