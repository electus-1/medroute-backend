using AutoMapper; 
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Location;

public class CreateLocationCommand : IRequest<Response<int>>
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; } 
    public string? Url { get; set; }
}

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Response<int>>
{
    private readonly IMapper _mapper;
    private readonly ILocationRepository _locationRepository;

    public CreateLocationCommandHandler(IMapper mapper, ILocationRepository locationRepository)
    {
        _mapper = mapper;
        _locationRepository = locationRepository;

    }

    public async Task<Response<int>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = _mapper.Map<Entities.Location>(request);
        await _locationRepository.CreateAsync(location);
        return new Response<int>(location.Id);
    }
}