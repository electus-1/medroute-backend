using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hospital;

public class FilterHospitalByLocationQuery : IRequest<Response<IEnumerable<GetHospitalViewModel>>>
{
    public double CenterLatitude { get; set; }
    public double CenterLongitude { get; set; }
    public double Radius { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHospitalByLocationQueryHandler : IRequestHandler<FilterHospitalByLocationQuery,
    Response<IEnumerable<GetHospitalViewModel>>>
{

    private readonly IMapper _mapper;
    private readonly IHospitalRepository _hospitalRepository;


    public FilterHospitalByLocationQueryHandler(IMapper mapper, IHospitalRepository hospitalRepository)
    {
        _mapper = mapper;
        _hospitalRepository = hospitalRepository;
    }

    public async Task<Response<IEnumerable<GetHospitalViewModel>>> Handle(FilterHospitalByLocationQuery request, CancellationToken cancellationToken)
    {
        var hospitals = await _hospitalRepository.FilterHospitalByLocation(request.CenterLatitude,
            request.CenterLongitude, request.Radius, request.RequestedNumber);
        var hospitalViewModels = _mapper.Map<IEnumerable<GetHospitalViewModel>>(hospitals);
        return new Response<IEnumerable<GetHospitalViewModel>>(hospitalViewModels);
    }
}