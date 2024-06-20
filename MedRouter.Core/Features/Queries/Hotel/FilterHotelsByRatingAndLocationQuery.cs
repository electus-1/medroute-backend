using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hotel;

public class FilterHotelsByRatingAndLocationQuery : IRequest<Response<IEnumerable<GetHotelViewModel>>>
{
    public int StarRating { get; set; }
    public double CenterLatitude { get; set; }
    public double CenterLongitude { get; set; }
    public double Radius { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHotelsByRatingAndLocationQueryHandler : IRequestHandler<FilterHotelsByRatingAndLocationQuery,
    Response<IEnumerable<GetHotelViewModel>>>
{
    private readonly IMapper _mapper;
    private readonly IHotelRepository _hotelRepository;

    public FilterHotelsByRatingAndLocationQueryHandler(IMapper mapper, IHotelRepository hotelRepository)
    {
        _mapper = mapper;
        _hotelRepository = hotelRepository;
    }

    public async Task<Response<IEnumerable<GetHotelViewModel>>> Handle(FilterHotelsByRatingAndLocationQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.FilterHotelByRatingAndLocation(request.StarRating ,request.CenterLatitude,
            request.CenterLongitude, request.Radius, request.RequestedNumber);
        var hotelViewModels = _mapper.Map<IEnumerable<GetHotelViewModel>>(hotels);
        return new Response<IEnumerable<GetHotelViewModel>>(hotelViewModels);
    }
}