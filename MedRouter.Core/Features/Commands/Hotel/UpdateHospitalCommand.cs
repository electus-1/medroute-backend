using AutoMapper;
using MediatR;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Hotel;

public class UpdateHotelCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public string HotelName { get; set; }
    public int StartRating { get; set; }
    
}

public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, Response<int>>
{
    private readonly IMapper _mapper;
    private readonly IHotelRepository _hotelRepository;

    public UpdateHotelCommandHandler(IMapper mapper, IHotelRepository hotelRepository)
    {
        _mapper = mapper;
        _hotelRepository = hotelRepository;
    }

    public async Task<Response<int>> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = _mapper.Map<Entities.Hotel>(request);
        await _hotelRepository.UpdateAsync(hotel);
        return new Response<int>(hotel.Id);
    }
}