using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Hospital;

public class DeleteHospitalCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    
}

public class DeleteHospitalCommandHandler : IRequestHandler<DeleteHospitalCommand, Response<int>>
{
    private readonly IHospitalRepository _hospitalRepository;

    public DeleteHospitalCommandHandler(IHospitalRepository hospitalRepository)
    {
        _hospitalRepository = hospitalRepository;
    }

    public async Task<Response<int>> Handle(DeleteHospitalCommand request, CancellationToken cancellationToken)
    {
        var hospital = await _hospitalRepository.GetByIdAsync(request.Id);
        if (hospital == null)
        {
            throw new ApiException($"Hospital {request.Id} not found!");
        }

        await _hospitalRepository.DeleteAsync(hospital);
        return new Response<int>(hospital.Id);
    }
}