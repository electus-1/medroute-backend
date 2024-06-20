using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hospital;

public class FilterHospitalsByNameAndTypeQuery : IRequest<Response<IEnumerable<GetHospitalViewModel>>>
{
    public string Filter { get; set; }
    public string Type { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHospitalsByNameAndTypeQueryHandler : IRequestHandler<FilterHospitalsByNameAndTypeQuery,
    Response<IEnumerable<GetHospitalViewModel>>>
{
    private readonly IMapper _mapper;
    private readonly IHospitalRepository _hospitalRepository;
    
    public async Task<Response<IEnumerable<GetHospitalViewModel>>> Handle(FilterHospitalsByNameAndTypeQuery request, CancellationToken cancellationToken)
    {
        var hospitals =
            await _hospitalRepository.FilterHospitalByNameAndType(request.Filter, request.Type,
                request.RequestedNumber);
        var hospitalViewModels = _mapper.Map<IEnumerable<GetHospitalViewModel>>(hospitals);
        return new Response<IEnumerable<GetHospitalViewModel>>(hospitalViewModels);
    }
}