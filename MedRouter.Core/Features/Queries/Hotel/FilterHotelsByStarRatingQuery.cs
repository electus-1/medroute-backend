using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hotel;

public class FilterHotelsByStarRatingQuery : IRequest<Response<IEnumerable<GetHotelViewModel>>>
{
    public int StarRating { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHotelsByStarRatingQueryHandler : IRequestHandler<FilterHotelsByStarRatingQuery, Response<IEnumerable<GetHotelViewModel>>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public FilterHotelsByStarRatingQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetHotelViewModel>>> Handle(FilterHotelsByStarRatingQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.FilterByStarRating(request.StarRating, request.RequestedNumber);
        var hotelViewModels = _mapper.Map<IEnumerable<GetHotelViewModel>>(hotels);
        return new Response<IEnumerable<GetHotelViewModel>>(hotelViewModels);
    }
}