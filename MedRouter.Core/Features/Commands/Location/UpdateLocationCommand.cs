using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Location;

public class UpdateLocationCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; } 
    public string? Url { get; set; }
}

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Response<int>>
{
    private IMapper _mapper;
    private ILocationRepository _locationRepository;

    public UpdateLocationCommandHandler(IMapper mapper, ILocationRepository locationRepository)
    {
        _mapper = mapper;
        _locationRepository = locationRepository;
    }

    public async Task<Response<int>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = _mapper.Map<Entities.Location>(request);
        await _locationRepository.UpdateAsync(location);
        return new Response<int>(location.Id);
    }
}