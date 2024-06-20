using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Landmark;

public class FilterLandmarksByLocationQuery : IRequest<Response<IEnumerable<GetLandmarkViewModel>>>
{
    public double CenterLatitude { get; set; }
    public double CenterLongitude { get; set; }
    public double Radius { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterLandmarksByLocationQueryHandler : IRequestHandler<FilterLandmarksByLocationQuery,
    Response<IEnumerable<GetLandmarkViewModel>>>
{

    private readonly IMapper _mapper;
    private readonly ILandmarkRepository _landmarkRepository;


    public FilterLandmarksByLocationQueryHandler(IMapper mapper, ILandmarkRepository landmarkRepository)
    {
        _mapper = mapper;
        _landmarkRepository = landmarkRepository;
    }

    public async Task<Response<IEnumerable<GetLandmarkViewModel>>> Handle(FilterLandmarksByLocationQuery request, CancellationToken cancellationToken)
    {
        var landmarks = await _landmarkRepository.FilterLandmarkByLocation(request.CenterLatitude,
            request.CenterLongitude, request.Radius, request.RequestedNumber);
        var landmarksViewModels = _mapper.Map<IEnumerable<GetLandmarkViewModel>>(landmarks);
        return new Response<IEnumerable<GetLandmarkViewModel>>(landmarksViewModels);
    }
}