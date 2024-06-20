using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Landmark;

public class DeleteLandmarkCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    
}

public class DeleteLandmarkCommandHandler : IRequestHandler<DeleteLandmarkCommand, Response<int>>
{
    private readonly ILandmarkRepository _landmarkRepository;

    public DeleteLandmarkCommandHandler(ILandmarkRepository landmarkRepository)
    {
        _landmarkRepository = landmarkRepository;
    }

    public async Task<Response<int>> Handle(DeleteLandmarkCommand request, CancellationToken cancellationToken)
    {
        var landmark = await _landmarkRepository.GetByIdAsync(request.Id);
        if (landmark == null)
        {
            throw new ApiException($"Landmark {request.Id} not found!");
        }

        await _landmarkRepository.DeleteAsync(landmark);
        return new Response<int>(landmark.Id);
    }
}