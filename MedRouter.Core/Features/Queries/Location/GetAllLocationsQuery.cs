using AutoMapper;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using MedRouter.Core.Interfaces.Repository;

namespace MedRouter.Core.Features.Queries.Location;

public class GetAllLocationsQuery : IRequest<PagedResponse<IEnumerable<GetLocationViewModel>>> 
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    
}

public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery,PagedResponse<IEnumerable<GetLocationViewModel>>>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public GetAllLocationsQueryHandler(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<IEnumerable<GetLocationViewModel>>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        var location = await _locationRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
        var locationViewModel = _mapper.Map<IEnumerable<GetLocationViewModel>>(location);
        return new PagedResponse<IEnumerable<GetLocationViewModel>>(locationViewModel, request.PageNumber, request.PageSize);
    }
}