using MedRouter.Core.Entities;
using MedRouter.Core.Features.Queries.Hotel;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Infrastructure.Contexts;
using MedRouter.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace MedRouter.Infrastructure.Repositories;

public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
{
    private readonly DbSet<Hotel> _hotels;
    
    public HotelRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _hotels = dbContext.Set<Hotel>();
    }

    public async Task<IReadOnlyList<Hotel>> FilterHotelsByName(string filter, int requestedNumber)
    {
        return await _hotels.Where(h => h.HotelName.ToLower().StartsWith(filter.ToLower())).Take(requestedNumber).ToListAsync();
    }  
    public async Task<IReadOnlyList<Hotel>> FilterByStarRating(int starRating, int requestedNumber)
    {
        return await _hotels.Where(h => h.StartRating >= starRating).Take(requestedNumber).ToListAsync();
    }

    public async Task<IReadOnlyList<Hotel>> FilterByNameAndStarRating(string filter, int starRating,
        int requestedNumber)
    {
        return await _hotels.Where(h => h.HotelName.ToLower().StartsWith(filter.ToLower()))
            .Where(h => h.StartRating >= starRating).Take(requestedNumber).ToListAsync();
    }
    
    public async Task<IReadOnlyList<Hotel>> FilterHotelByLocation(double centerLatitude, double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _hotels.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Take(requestedNumber).ToListAsync();
    }
    
    public async Task<IReadOnlyList<Hotel>> FilterHotelByNameAndLocation(string filter, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _hotels.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Where(h => h.HotelName.ToLower().StartsWith(filter.ToLower())).Take(requestedNumber).ToListAsync();
    }
    
    public async Task<IReadOnlyList<Hotel>> FilterHotelByRatingAndLocation(int starRating, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _hotels.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Where(h => h.StartRating >= starRating).Take(requestedNumber).ToListAsync();
    }

    public async Task<IReadOnlyList<Hotel>> FilterHotelByNameAndRatingAndLocation(string filter, int starRating, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _hotels.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Where(h => h.StartRating >= starRating).Where(h => h.HotelName.ToLower().StartsWith(filter.ToLower())).Take(requestedNumber).ToListAsync();
    }
}