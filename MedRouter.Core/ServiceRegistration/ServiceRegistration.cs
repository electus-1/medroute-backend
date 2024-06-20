using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MedRouter.Core.Mappings;

namespace MedRouter.Core.ServiceRegistration;

public static class ServiceRegistration
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(GeneralProfile));
        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}
