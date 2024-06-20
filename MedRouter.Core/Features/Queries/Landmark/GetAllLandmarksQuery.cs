using AutoMapper;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using MedRouter.Core.Features.Queries.Location;
using MedRouter.Core.Interfaces.Repository;

namespace MedRouter.Core.Features.Queries.Landmark;

public class GetAllLandmarksQuery : IRequest<PagedResponse<IEnumerable<GetLandmarkViewModel>>> 
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    
}

public class GetAllLandmarksQueryHandler : IRequestHandler<GetAllLandmarksQuery,PagedResponse<IEnumerable<GetLandmarkViewModel>>>
{
    private readonly ILandmarkRepository _landmarkRepository;
    private readonly IMapper _mapper;

    public GetAllLandmarksQueryHandler(ILandmarkRepository landmarkRepository, IMapper mapper)
    {
        _landmarkRepository = landmarkRepository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<IEnumerable<GetLandmarkViewModel>>> Handle(GetAllLandmarksQuery request, CancellationToken cancellationToken)
    {
        var landmark = await _landmarkRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
        var landmarkViewModel = _mapper.Map<IEnumerable<GetLandmarkViewModel>>(landmark);
        return new PagedResponse<IEnumerable<GetLandmarkViewModel>>(landmarkViewModel, request.PageNumber, request.PageSize);
    }
}