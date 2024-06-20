using MedRouter.Core.Entities;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedRouter.Infrastructure.Repositories;

public class LocationRepository : GenericRepository<Location>, ILocationRepository
{
    private readonly DbSet<Location> _locations;
    public LocationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _locations = dbContext.Set<Location>();
    }
}