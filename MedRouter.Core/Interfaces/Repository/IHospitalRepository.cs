using MedRouter.Core.Entities;

namespace MedRouter.Core.Interfaces.Repository;

public interface IHospitalRepository : IGenericRepository<Hospital>
{
    public Task<IReadOnlyList<Hospital>> FilterHospitalsByName(string filter, int requestedNumber);
    public Task<IReadOnlyList<Hospital>> FilterHospitalsByType(string type, int requestedNumber);

    public Task<IReadOnlyList<Hospital>> FilterHospitalByNameAndType(string filter, string type,
        int requestedNumber);

    public Task<IReadOnlyList<Hospital>> FilterHospitalByLocation(double centerLatitude, double centerLongitude,
        double radius, int requestedNumber);

    public Task<IReadOnlyList<Hospital>> FilterHospitalByNameAndLocation(string filter, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber);

    public Task<IReadOnlyList<Hospital>> FilterHospitalByTypeAndLocation(string type, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber);

    public Task<IReadOnlyList<Hospital>> FilterHospitalByNameAndTypeAndLocation(string filter, string type,
        double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber);
}