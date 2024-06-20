using AutoMapper;
using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Location;

public class GetLocationByIdQuery : IRequest<Response<GetLocationViewModel>>
{
    public int Id { get; set; }
    
}

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Response<GetLocationViewModel>>
{
    private readonly ILocationRepository _locationRepository;
    private IMapper _mapper;
    public GetLocationByIdQueryHandler(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetLocationViewModel>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var location = await _locationRepository.GetByIdAsync(request.Id);
        if (location == null) throw new ApiException($"Location {request.Id} not found");
        var locationViewModel = _mapper.Map<GetLocationViewModel>(location);
        return new Response<GetLocationViewModel>(locationViewModel);
    }
}