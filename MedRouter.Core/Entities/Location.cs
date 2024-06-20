namespace MedRouter.Core.Entities;

public class Location : BaseEntity
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; } 
    public string? Url { get; set; }
}