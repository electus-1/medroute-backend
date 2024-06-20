using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Hotel;

public class CreateHotelCommand : IRequest<Response<int>>
{
    public int LocationId { get; set; }
    public string HotelName { get; set; }
    public int StartRating { get; set; }
}

public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, Response<int>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public CreateHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = _mapper.Map<Entities.Hotel>(request);
        await _hotelRepository.CreateAsync(hotel);
        return new Response<int>(hotel.Id);
    }
}