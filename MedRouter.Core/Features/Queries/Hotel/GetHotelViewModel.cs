namespace MedRouter.Core.Features.Queries.Hotel;

public class GetHotelViewModel
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public string HotelName { get; set; }
    public int StartRating { get; set; }
}