using Microsoft.Extensions.DependencyInjection;

namespace Persistance.Base
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration config)
        {
           
            return services;
        }
    }
}
