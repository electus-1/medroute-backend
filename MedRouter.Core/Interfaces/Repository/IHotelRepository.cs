using MedRouter.Core.Entities;

namespace MedRouter.Core.Interfaces.Repository;

public interface IHotelRepository : IGenericRepository<Hotel>
{
    public Task<IReadOnlyList<Hotel>> FilterHotelsByName(string filter, int requestedNumber);
    public Task<IReadOnlyList<Hotel>> FilterByStarRating(int starRating, int requestedNumber);

    public Task<IReadOnlyList<Hotel>> FilterByNameAndStarRating(string filter, int starRating,
        int requestedNumber);

    public Task<IReadOnlyList<Hotel>> FilterHotelByLocation(double centerLatitude, double centerLongitude,
        double radius, int requestedNumber);

    public Task<IReadOnlyList<Hotel>> FilterHotelByNameAndLocation(string filter, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber);

    public Task<IReadOnlyList<Hotel>> FilterHotelByRatingAndLocation(int starRating, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber);

    public Task<IReadOnlyList<Hotel>> FilterHotelByNameAndRatingAndLocation(string filter, int starRating,
        double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber);
}