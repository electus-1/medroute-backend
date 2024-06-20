using System.Collections;
using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Landmark;

public class FilterLandmarksByNameQuery : IRequest<Response<IEnumerable<GetLandmarkViewModel>>>
{
    public string Filter { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterLandmarksByNameQueryHandler : IRequestHandler<FilterLandmarksByNameQuery, Response<IEnumerable<GetLandmarkViewModel>>>
{
    private readonly ILandmarkRepository _landmarkRepository;
    private readonly IMapper _mapper;

    public FilterLandmarksByNameQueryHandler(ILandmarkRepository landmarkRepository, IMapper mapper)
    {
        _landmarkRepository = landmarkRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetLandmarkViewModel>>> Handle(FilterLandmarksByNameQuery request, CancellationToken cancellationToken)
    {
        var landmarks = await _landmarkRepository.FilterLandmarksByName(request.Filter, request.RequestedNumber);
        var landmarkViewModels = _mapper.Map<IEnumerable<GetLandmarkViewModel>>(landmarks);
        return new Response<IEnumerable<GetLandmarkViewModel>>(landmarkViewModels);
    }
}