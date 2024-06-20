using MedRouter.Core.Entities;
using MedRouter.Core.Interfaces.Repository;
using MedRouter.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedRouter.Infrastructure.Repositories;

public class RouteRepository : GenericRepository<Route>, IRouteRepository
{
    private readonly DbSet<Route> _routes;
    public RouteRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _routes = dbContext.Set<Route>();
    }

    public async Task<IEnumerable<Route>> GetByMail(string mail, CancellationToken cancellationToken)
    {
        return await _routes.Where(r => r.Mail == mail).ToListAsync(cancellationToken);
    }
}