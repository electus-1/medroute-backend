namespace MedRouter.Core.Entities;

public class Hospital : BaseEntity
{
    public int LocationId { get; set; }
    public string HospitalName { get; set; }
    public string HospitalType { get; set; }
    public virtual Location Location { get; set; }
}