using MedRouter.Core.Entities;

namespace MedRouter.Core.Interfaces.Repository;

public interface ILandmarkRepository : IGenericRepository<Landmark>
{
    public Task<IReadOnlyList<Landmark>> FilterLandmarksByName(string filter, int requestedNumber);

    public Task<IReadOnlyList<Landmark>> FilterLandmarkByLocation(double centerLatitude, double centerLongitude,
        double radius, int requestedNumber);

    public Task<IReadOnlyList<Landmark>> FilterLandmarkByNameAndLocation(string filter, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber);
}