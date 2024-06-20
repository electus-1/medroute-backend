using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Location;

public class DeleteLocationCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
}

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Response<int>>
{
    private readonly ILocationRepository _locationRepository;

    public DeleteLocationCommandHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Response<int>> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _locationRepository.GetByIdAsync(request.Id);
        if (location == null)
        {
            throw new ApiException($"Location {request.Id} not found");
        }
        await _locationRepository.DeleteAsync(location);
        return new Response<int>(location.Id);
    }
}