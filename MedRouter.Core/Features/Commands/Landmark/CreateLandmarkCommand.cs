using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Landmark;

public class CreateLandmarkCommand : IRequest<Response<int>>
{
    public int LocationId { get; set; }
    public string LandmarkName { get; set; }
    public string LandmarkInfo { get; set; }
}

public class CreateLandmarkCommandHandler : IRequestHandler<CreateLandmarkCommand, Response<int>>
{
    private readonly ILandmarkRepository _landmarkRepository;
    private readonly IMapper _mapper;

    public CreateLandmarkCommandHandler(ILandmarkRepository landmarkRepository, IMapper mapper)
    {
        _landmarkRepository = landmarkRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateLandmarkCommand request, CancellationToken cancellationToken)
    {
        var landmark = _mapper.Map<Entities.Landmark>(request);
        await _landmarkRepository.CreateAsync(landmark);
        return new Response<int>(landmark.Id);
    }
}