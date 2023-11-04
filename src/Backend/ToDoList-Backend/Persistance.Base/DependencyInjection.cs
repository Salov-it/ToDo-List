using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance.Base
{
    public static class DependencyInjection
    {
       
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Context>(options =>
            options.UseNpgsql(Config.Connect));

            return services;
        }
    }
}
