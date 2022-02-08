using HotelsInCities.Infrastructure.DataAccess.Repositories.UnitOfWork;
using HotelsInCities.Infrastructure.Interfaces.Repositories.UnitOfWork;

namespace HotelsInCities.ServicesConfiguration
{
    public static class RepositoryConfiguration
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
