using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hospital;

public class FilterHospitalByTypeAndLocationQuery : IRequest<Response<IEnumerable<GetHospitalViewModel>>>
{
    public string Type { get; set; }
    public double CenterLatitude { get; set; }
    public double CenterLongitude { get; set; }
    public double Radius { get; set; }
    public int RequestedNumber { get; set; }
}


public class FilterHospitalByTypeAndLocationQueryHandler : IRequestHandler<FilterHospitalByTypeAndLocationQuery ,Response<IEnumerable<GetHospitalViewModel>>>
{
    private readonly IMapper _mapper;
    private readonly IHospitalRepository _hospitalRepository;

    public FilterHospitalByTypeAndLocationQueryHandler(IMapper mapper, IHospitalRepository hospitalRepository)
    {
        _mapper = mapper;
        _hospitalRepository = hospitalRepository;
    }

    public async Task<Response<IEnumerable<GetHospitalViewModel>>> Handle(FilterHospitalByTypeAndLocationQuery request, CancellationToken cancellationToken)
    {
        var hospitals = await _hospitalRepository.FilterHospitalByTypeAndLocation(request.Type, request.CenterLatitude,
            request.CenterLongitude, request.Radius, request.RequestedNumber);
        var hospitalViewModels = _mapper.Map<IEnumerable<GetHospitalViewModel>>(hospitals);
        return new Response<IEnumerable<GetHospitalViewModel>>(hospitalViewModels);
    }
}

