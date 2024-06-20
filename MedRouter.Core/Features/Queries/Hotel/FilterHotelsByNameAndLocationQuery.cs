using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hotel;

public class FilterHotelsByNameAndLocationQuery : IRequest<Response<IEnumerable<GetHotelViewModel>>>
{
    public string Filter { get; set; }
    public double CenterLatitude { get; set; }
    public double CenterLongitude { get; set; }
    public double Radius { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHotelsByNameAndLocationQueryHandler : IRequestHandler<FilterHotelsByNameAndLocationQuery,
    Response<IEnumerable<GetHotelViewModel>>>
{

    private readonly IMapper _mapper;
    private readonly IHotelRepository _hotelRepository;


    public FilterHotelsByNameAndLocationQueryHandler(IMapper mapper, IHotelRepository hotelRepository)
    {
        _mapper = mapper;
        _hotelRepository = hotelRepository;
    }

    public async Task<Response<IEnumerable<GetHotelViewModel>>> Handle(FilterHotelsByNameAndLocationQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.FilterHotelByNameAndLocation(request.Filter ,request.CenterLatitude,
            request.CenterLongitude, request.Radius, request.RequestedNumber);
        var hotelViewModels = _mapper.Map<IEnumerable<GetHotelViewModel>>(hotels);
        return new Response<IEnumerable<GetHotelViewModel>>(hotelViewModels);
    }
}