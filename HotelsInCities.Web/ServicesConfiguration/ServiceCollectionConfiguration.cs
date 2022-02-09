using HotelsInCities.Application.Intefaces.Interfaces;
using HotelsInCities.Infrastructure.WeatherForecast.Interfaces;
using HotelsInCities.Infrastructure.WeatherForecast.Services;
using HotelsInCities.Services.Services.Implementation;

namespace HotelsInCities.ServicesConfiguration
{
    public static class ServiceCollectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IWeatherForeacstService, WeatherForecastService>();
        }
    }
}
