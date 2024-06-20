using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Landmark;

public class FilterLandmarksByNameAndLocationQuery : IRequest<Response<IEnumerable<GetLandmarkViewModel>>>
{
    public string Filter { get; set; }
    public double CenterLatitude { get; set; }
    public double CenterLongitude { get; set; }
    public double Radius { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterLandmarksByNameAndLocationQueryHandler : IRequestHandler<FilterLandmarksByNameAndLocationQuery,
    Response<IEnumerable<GetLandmarkViewModel>>>
{

    private readonly IMapper _mapper;
    private readonly ILandmarkRepository _landmarkRepository;


    public FilterLandmarksByNameAndLocationQueryHandler(IMapper mapper, ILandmarkRepository landmarkRepository)
    {
        _mapper = mapper;
        _landmarkRepository = landmarkRepository;
    }

    public async Task<Response<IEnumerable<GetLandmarkViewModel>>> Handle(FilterLandmarksByNameAndLocationQuery request, CancellationToken cancellationToken)
    {
        var landmarks = await _landmarkRepository.FilterLandmarkByNameAndLocation(request.Filter, request.CenterLatitude,
            request.CenterLongitude, request.Radius, request.RequestedNumber);
        var landmarksViewModels = _mapper.Map<IEnumerable<GetLandmarkViewModel>>(landmarks);
        return new Response<IEnumerable<GetLandmarkViewModel>>(landmarksViewModels);
    }
}