namespace MedRouter.Core.Features.Queries.Location;

public class GetLocationViewModel
{
    public virtual int Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; } 
    public string? Url { get; set; }
}