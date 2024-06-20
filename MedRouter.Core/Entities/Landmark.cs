namespace MedRouter.Core.Entities;

public class Landmark : BaseEntity
{
    public int LocationId { get; set; }
    public string LandmarkName { get; set; }
    public string LandmarkInfo { get; set; }
    public virtual Location Location { get; set;}
}