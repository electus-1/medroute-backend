using MedRouter.Core.Entities;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Infrastructure.Contexts;
using MedRouter.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace MedRouter.Infrastructure.Repositories;

public class LandmarkRepository : GenericRepository<Landmark>, ILandmarkRepository
{
    private readonly DbSet<Landmark> _landmarks;
    
    public LandmarkRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _landmarks = dbContext.Set<Landmark>();
    }
    
    public async Task<IReadOnlyList<Landmark>> FilterLandmarksByName(string filter, int requestedNumber)
    {
        return await _landmarks.Where(l => l.LandmarkName.ToLower().StartsWith(filter.ToLower())).Take(requestedNumber)
            .ToListAsync();
    }
    
    public async Task<IReadOnlyList<Landmark>> FilterLandmarkByLocation(double centerLatitude, double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _landmarks.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Take(requestedNumber).ToListAsync();  
    }
    
    public async Task<IReadOnlyList<Landmark>> FilterLandmarkByNameAndLocation(string filter, double centerLatitude, double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _landmarks.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius).Where(l => l.LandmarkName.ToLower().StartsWith(filter.ToLower())).Take(requestedNumber).ToListAsync();
    }
}