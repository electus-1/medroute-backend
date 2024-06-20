namespace MedRouter.Core.Entities;

public class Hotel : BaseEntity
{
    public int LocationId { get; set; }
    public string HotelName { get; set; }
    public int StartRating { get; set; }
    public virtual Location Location { get; set; }
}