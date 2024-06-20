using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Hospital;

public class CreateHospitalCommand : IRequest<Response<int>>
{
    public int LocationId { get; set; }
    public string HospitalName { get; set; }
    public string HospitalType { get; set; }
}

public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommand, Response<int>>
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IMapper _mapper;

    public CreateHospitalCommandHandler(IHospitalRepository hospitalRepository, IMapper mapper)
    {
        _hospitalRepository = hospitalRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
    {
        var hospital = _mapper.Map<Entities.Hospital>(request);
        await _hospitalRepository.CreateAsync(hospital);
        return new Response<int>(hospital.Id);
    }
}