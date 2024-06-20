using AutoMapper;
using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Queries.Hotel;

public class GetHotelByIdQuery : IRequest<Response<GetHotelViewModel>>
{
    public int Id { get; set; }
}

public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, Response<GetHotelViewModel>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetHotelByIdQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetHotelViewModel>> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(request.Id);
        if (hotel == null)
        {
            throw new ApiException($"Hotel {request.Id} not found.");
        }

        var hotelViewModel = _mapper.Map<GetHotelViewModel>(hotel);

        return new Response<GetHotelViewModel>(hotelViewModel);
    }
}