using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hotel;

public class FilterHotelsByNameQuery : IRequest<Response<IEnumerable<GetHotelViewModel>>>
{
    public string Filter { get; set; }
    public int RequestedNumber { get; set; }
}

public class FilterHotelsByNameQueryHandler : IRequestHandler<FilterHotelsByNameQuery, Response<IEnumerable<GetHotelViewModel>>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public FilterHotelsByNameQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<GetHotelViewModel>>> Handle(FilterHotelsByNameQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.FilterHotelsByName(request.Filter, request.RequestedNumber);
        var hotelViewModels = _mapper.Map<IEnumerable<GetHotelViewModel>>(hotels);
        return new Response<IEnumerable<GetHotelViewModel>>(hotelViewModels);
    }
}