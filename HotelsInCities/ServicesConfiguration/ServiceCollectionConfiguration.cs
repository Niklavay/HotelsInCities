using HotelsInCities.Services.Intefaces.Interfaces;
using HotelsInCities.Services.Services.Implementation;

namespace HotelsInCities.ServicesConfiguration
{
    public static class ServiceCollectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IHotelService, HotelService>();
        }
    }
}
