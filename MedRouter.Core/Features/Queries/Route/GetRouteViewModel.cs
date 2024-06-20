namespace MedRouter.Core.Features.Queries.Route;

public class GetRouteViewModel
{
    public  int Id { get; set; }
    public string Mail { get; set; }
    public int? HotelId { get; set; }
    public int? HospitalId { get; set; }
    public string Type { get; set; }
    public string RouteName { get; set; }
}