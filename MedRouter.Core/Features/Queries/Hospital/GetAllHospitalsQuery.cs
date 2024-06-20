using AutoMapper;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using MedRouter.Core.Features.Queries.Location;
using MedRouter.Core.Interfaces.Repository;

namespace MedRouter.Core.Features.Queries.Hospital;

public class GetAllHospitalsQuery : IRequest<PagedResponse<IEnumerable<GetHospitalViewModel>>> 
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    
}

public class GetAllHospitalsQueryHandler : IRequestHandler<GetAllHospitalsQuery,PagedResponse<IEnumerable<GetHospitalViewModel>>>
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IMapper _mapper;

    public GetAllHospitalsQueryHandler(IHospitalRepository hospitalRepository, IMapper mapper)
    {
        _hospitalRepository = hospitalRepository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<IEnumerable<GetHospitalViewModel>>> Handle(GetAllHospitalsQuery request, CancellationToken cancellationToken)
    {
        var hospital = await _hospitalRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
        var hospitalViewModel = _mapper.Map<IEnumerable<GetHospitalViewModel>>(hospital);
        return new PagedResponse<IEnumerable<GetHospitalViewModel>>(hospitalViewModel, request.PageNumber, request.PageSize);
    }
}