using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hospital;

public class FilterHospitalsByNameQuery : IRequest<Response<IEnumerable<GetHospitalViewModel>>>
{
    public string Filter { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHospitalsByNameQueryHandler : IRequestHandler<FilterHospitalsByNameQuery, Response<IEnumerable<GetHospitalViewModel>>>
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IMapper _mapper;

    public FilterHospitalsByNameQueryHandler(IHospitalRepository hospitalRepository, IMapper mapper)
    {
        _hospitalRepository = hospitalRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetHospitalViewModel>>> Handle(FilterHospitalsByNameQuery request, CancellationToken cancellationToken)
    {
        var hospitals = await _hospitalRepository.FilterHospitalsByName(request.Filter, request.RequestedNumber);
        var hospitalViewModels = _mapper.Map<IEnumerable<GetHospitalViewModel>>(hospitals);
        return new Response<IEnumerable<GetHospitalViewModel>>(hospitalViewModels);
    }
}