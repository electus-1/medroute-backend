using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hospital;

public class FilterHospitalByNameAndTypeAndLocationQuery : IRequest<Response<IEnumerable<GetHospitalViewModel>>>
{
    public string Filter { get; set; }
    public string Type { get; set; }
    public double CenterLatitude { get; set; }
    public double CenterLongitude { get; set; }
    public double Radius { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHospitalByNameAndTypeAndLocationQueryHandler : IRequestHandler<FilterHospitalByNameAndTypeAndLocationQuery, Response<IEnumerable<GetHospitalViewModel>>>
{
    private readonly IMapper _mapper;
    private readonly IHospitalRepository _hospitalRepository;

    public FilterHospitalByNameAndTypeAndLocationQueryHandler(IMapper mapper, IHospitalRepository hospitalRepository)
    {
        _mapper = mapper;
        _hospitalRepository = hospitalRepository;
    }

    public async Task<Response<IEnumerable<GetHospitalViewModel>>> Handle(FilterHospitalByNameAndTypeAndLocationQuery request, CancellationToken cancellationToken)
    {
        var hospitals = await _hospitalRepository.FilterHospitalByNameAndTypeAndLocation(request.Filter, request.Type,
            request.CenterLatitude, request.CenterLongitude, request.Radius, request.RequestedNumber);
        var hospitalViewModels = _mapper.Map<IEnumerable<GetHospitalViewModel>>(hospitals);
        return new Response<IEnumerable<GetHospitalViewModel>>(hospitalViewModels);
    }
}

