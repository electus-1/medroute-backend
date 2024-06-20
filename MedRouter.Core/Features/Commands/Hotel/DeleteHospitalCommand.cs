using MediatR;
using MedRouter.Core.Exceptions;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Features.Commands.Hotel;

public class DeleteHotelCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    
}

public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, Response<int>>
{
    private readonly IHotelRepository _hotelRepository;

    public DeleteHotelCommandHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<Response<int>> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(request.Id);
        if (hotel == null)
        {
            throw new ApiException($"Hotel {request.Id} not found!");
        }

        await _hotelRepository.DeleteAsync(hotel);
        return new Response<int>(hotel.Id);
    }
}