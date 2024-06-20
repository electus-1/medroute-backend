using MediatR;
using MedRouter.Core.Entities;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;


namespace MedRouter.Infrastructure.Repositories;

public class HospitalRepository :  GenericRepository<Hospital>,IHospitalRepository
{
    private readonly DbSet<Hospital> _hospitals;
    public HospitalRepository(ApplicationDbContext dbContext, IMediator mediator) : base(dbContext)
    {
        _hospitals = dbContext.Set<Hospital>();
    }
    public async Task<IReadOnlyList<Hospital>> FilterHospitalsByName(string filter, int requestedNumber)
    {
        return await _hospitals.Where(h => h.HospitalName.ToLower().StartsWith(filter.ToLower())).Take(requestedNumber).ToListAsync();
    }  
    
    public async Task<IReadOnlyList<Hospital>> FilterHospitalsByType(string type, int requestedNumber)
    {
        return await _hospitals.Where(h => h.HospitalType.ToLower().Equals(type.ToLower())).Take(requestedNumber).ToListAsync();
    }

    public async Task<IReadOnlyList<Hospital>> FilterHospitalByNameAndType(string filter, string type,
        int requestedNumber)
    {
        return await _hospitals.Where(h => h.HospitalType.ToLower().Equals(type.ToLower()))
            .Where(h => h.HospitalName.ToLower().StartsWith(filter.ToLower())).Take(requestedNumber).ToListAsync();
    }

    public async Task<IReadOnlyList<Hospital>> FilterHospitalByLocation(double centerLatitude, double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _hospitals.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Take(requestedNumber).ToListAsync();
    }

    public async Task<IReadOnlyList<Hospital>> FilterHospitalByNameAndLocation(string filter, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _hospitals.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Where(h => h.HospitalName.ToLower().StartsWith(filter.ToLower())).Take(requestedNumber).ToListAsync();
    }

    public async Task<IReadOnlyList<Hospital>> FilterHospitalByTypeAndLocation(string type, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _hospitals.Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Where(h => h.HospitalType.ToLower().Equals(type.ToLower())).Take(requestedNumber).ToListAsync();
    }
    
    public async Task<IReadOnlyList<Hospital>> FilterHospitalByNameAndTypeAndLocation(string filter, string type, double centerLatitude,
        double centerLongitude,
        double radius, int requestedNumber)
    {
        return await _hospitals.Where(h => h.HospitalName.ToLower().StartsWith(filter.ToLower())).Where(h => 6371 * Math.Acos(
                Math.Cos(centerLatitude * Math.PI / 180.0)
                * Math.Cos(h.Location.Latitude * Math.PI / 180.0)
                * Math.Cos((h.Location.Longitude * Math.PI / 180.0) - (centerLongitude* Math.PI / 180.0)) 
                +  Math.Sin(centerLatitude * Math.PI / 180.0) 
                * Math.Sin(h.Location.Latitude * Math.PI / 180.0) 
            ) <= radius
        ).Where(h => h.HospitalType.ToLower().Equals(type.ToLower())).Take(requestedNumber).ToListAsync();
    }
}