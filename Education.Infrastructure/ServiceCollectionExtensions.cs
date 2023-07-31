using Education.Domain;
using Education.Infrastructure.Caching;
using Education.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Education.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddEntityFrameworkNpgsql().AddDbContext<EducationDbContext>(optionsAction: opt =>
             opt.UseNpgsql(configuration["DatabaseSettings:ConnectionString"]));
            serviceCollection.AddSingleton<RedisServer>();
            serviceCollection.AddSingleton<ICacheService, RedisCacheService>();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }
    }
}
    