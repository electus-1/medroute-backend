namespace MedRouter.Core.Features.Queries.Landmark;

public class GetLandmarkViewModel
{
    public  int Id { get; set; }
    public int LocationId { get; set; }
    public string LandmarkName { get; set; }
    public string LandmarkInfo { get; set; }
}