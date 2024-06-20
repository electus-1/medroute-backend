using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Landmark;

public class UpdateLandmarkCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public string LandmarkName { get; set; }
    public string LandmarkInfo { get; set; }
    
}

public class UpdateLandmarkCommandHandler : IRequestHandler<UpdateLandmarkCommand, Response<int>>
{
    private readonly IMapper _mapper;
    private readonly ILandmarkRepository _landmarkRepository;

    public UpdateLandmarkCommandHandler(IMapper mapper, ILandmarkRepository landmarkRepository)
    {
        _mapper = mapper;
        _landmarkRepository = landmarkRepository;
    }

    public async Task<Response<int>> Handle(UpdateLandmarkCommand request, CancellationToken cancellationToken)
    {
        var landmark = _mapper.Map<Entities.Landmark>(request);
        await _landmarkRepository.UpdateAsync(landmark);
        return new Response<int>(landmark.Id);
    }
}