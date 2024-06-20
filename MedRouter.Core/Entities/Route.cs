namespace MedRouter.Core.Entities;

public class Route : BaseEntity
{
    public string Mail { get; set; }
    public int? HotelId { get; set; }
    public int? HospitalId { get; set; }
    public string Type { get; set; }
    
    public string RouteName { get; set; }
    public virtual Hospital? Hospital { get; set; }
    public  virtual Hotel? Hotel { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; }
}