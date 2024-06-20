using MedRouter.Core.Entities;

namespace MedRouter.Core.Interfaces.Repository;

public interface IRouteRepository : IGenericRepository<Route>
{
    public Task<IEnumerable<Route>> GetByMail(string mail, CancellationToken cancellationToken);

}