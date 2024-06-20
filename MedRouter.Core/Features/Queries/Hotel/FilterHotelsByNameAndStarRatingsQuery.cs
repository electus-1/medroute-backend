using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hotel;

public class FilterHotelsByNameAndStarRatingsQuery : IRequest<Response<IEnumerable<GetHotelViewModel>>>
{
    public string Filter { get; set; }
    
    public int StarRating { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHotelsByNameAndStarRatingsQueryHandler : IRequestHandler<FilterHotelsByNameAndStarRatingsQuery, Response<IEnumerable<GetHotelViewModel>>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public FilterHotelsByNameAndStarRatingsQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetHotelViewModel>>> Handle(FilterHotelsByNameAndStarRatingsQuery request, CancellationToken cancellationToken)
    {
        var hotels =
            await _hotelRepository.FilterByNameAndStarRating(request.Filter, request.StarRating,
                request.RequestedNumber);
        var hotelViewModels = _mapper.Map<IEnumerable<GetHotelViewModel>>(hotels);
        return new Response<IEnumerable<GetHotelViewModel>>(hotelViewModels);
    }
}