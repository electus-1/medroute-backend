using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Hospital;

public class UpdateHospitalCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public int? LocationId { get; set; }
    public string HospitalName { get; set; }
    public string HospitalType { get; set; }
    
}

public class UpdateHospitalCommandHandler : IRequestHandler<UpdateHospitalCommand, Response<int>>
{
    private readonly IMapper _mapper;
    private readonly IHospitalRepository _hospitalRepository;

    public UpdateHospitalCommandHandler(IMapper mapper, IHospitalRepository hospitalRepository)
    {
        _mapper = mapper;
        _hospitalRepository = hospitalRepository;
    }

    public async Task<Response<int>> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
    {
        var hospital = _mapper.Map<Entities.Hospital>(request);
        await _hospitalRepository.UpdateAsync(hospital);
        return new Response<int>(hospital.Id);
    }
}