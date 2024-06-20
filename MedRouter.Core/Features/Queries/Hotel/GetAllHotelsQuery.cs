using AutoMapper;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using MedRouter.Core.Features.Queries.Location;
using MedRouter.Core.Interfaces.Repository;

namespace MedRouter.Core.Features.Queries.Hotel;

public class GetAllHotelsQuery : IRequest<PagedResponse<IEnumerable<GetHotelViewModel>>> 
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    
}

public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery,PagedResponse<IEnumerable<GetHotelViewModel>>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetAllHotelsQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<IEnumerable<GetHotelViewModel>>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
        var hotelViewModel = _mapper.Map<IEnumerable<GetHotelViewModel>>(hotel);
        return new PagedResponse<IEnumerable<GetHotelViewModel>>(hotelViewModel, request.PageNumber, request.PageSize);
    }
}