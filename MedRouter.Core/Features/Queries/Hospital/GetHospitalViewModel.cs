namespace MedRouter.Core.Features.Queries.Hospital;

public class GetHospitalViewModel
{
    public  int Id { get; set; }
    public int LocationId { get; set; }
    public string HospitalName { get; set; }
    public string HospitalType { get; set; }
}