using AutoMapper;
using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Landmark;

public class GetLandmarkByIdQuery : IRequest<Response<GetLandmarkViewModel>>
{
    public int Id { get; set; }
}

public class GetLandmarkByIdQueryHandler : IRequestHandler<GetLandmarkByIdQuery, Response<GetLandmarkViewModel>>
{
    private readonly ILandmarkRepository _landmarkRepository;
    private readonly IMapper _mapper;

    public GetLandmarkByIdQueryHandler(ILandmarkRepository landmarkRepository, IMapper mapper)
    {
        _landmarkRepository = landmarkRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetLandmarkViewModel>> Handle(GetLandmarkByIdQuery request, CancellationToken cancellationToken)
    {
        var landmark = await _landmarkRepository.GetByIdAsync(request.Id);
        if (landmark == null)
        {
            throw new ApiException($"Landmark {request.Id} not found.");
        }

        var landmarkViewModel = _mapper.Map<GetLandmarkViewModel>(landmark);

        return new Response<GetLandmarkViewModel>(landmarkViewModel);
    }
}