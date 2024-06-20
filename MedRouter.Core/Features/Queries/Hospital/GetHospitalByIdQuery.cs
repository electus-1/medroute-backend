using AutoMapper;
using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hospital;

public class GetHospitalByIdQuery : IRequest<Response<GetHospitalViewModel>>
{
    public int Id { get; set; }
}

public class GetHospitalByIdQueryHandler : IRequestHandler<GetHospitalByIdQuery, Response<GetHospitalViewModel>>
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IMapper _mapper;

    public GetHospitalByIdQueryHandler(IHospitalRepository hospitalRepository, IMapper mapper)
    {
        _hospitalRepository = hospitalRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetHospitalViewModel>> Handle(GetHospitalByIdQuery request, CancellationToken cancellationToken)
    {
        var hospital = await _hospitalRepository.GetByIdAsync(request.Id);
        if (hospital == null)
        {
            throw new ApiException($"Hospital {request.Id} not found.");
        }

        var hospitalViewModel = _mapper.Map<GetHospitalViewModel>(hospital);

        return new Response<GetHospitalViewModel>(hospitalViewModel);
    }
}