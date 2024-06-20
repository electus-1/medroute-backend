using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hospital;

public class FilterHospitalsByTypeQuery : IRequest<Response<IEnumerable<GetHospitalViewModel>>>
{
    public string Type { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHospitalsByTypeQueryHandler : IRequestHandler<FilterHospitalsByTypeQuery, Response<IEnumerable<GetHospitalViewModel>>>
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IMapper _mapper;

    public FilterHospitalsByTypeQueryHandler(IHospitalRepository hospitalRepository, IMapper mapper)
    {
        _hospitalRepository = hospitalRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetHospitalViewModel>>> Handle(FilterHospitalsByTypeQuery request, CancellationToken cancellationToken)
    {
        var hospitals = await _hospitalRepository.FilterHospitalsByType(request.Type, request.RequestedNumber);
        var hospitalViewModels = _mapper.Map<IEnumerable<GetHospitalViewModel>>(hospitals);
        return new Response<IEnumerable<GetHospitalViewModel>>(hospitalViewModels);
    }
}