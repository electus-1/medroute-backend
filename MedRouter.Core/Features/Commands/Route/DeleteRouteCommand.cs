using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Route;

public class DeleteRouteCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
}

public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, Response<int>>
{
    private readonly IRouteRepository _routeRepository;

    public DeleteRouteCommandHandler(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public async Task<Response<int>> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
    {
        var route = await _routeRepository.GetByIdAsync(request.Id);
        if (route == null)
        {
            throw new ApiException($"Route {request.Id} not found");
        }
        await _routeRepository.DeleteAsync(route);
        return new Response<int>(route.Id);
    }
}