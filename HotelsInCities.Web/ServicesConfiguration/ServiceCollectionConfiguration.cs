using HotelsInCities.Application.Intefaces.Interfaces;
using HotelsInCities.Application.Services.Implementation;
using HotelsInCities.Domain.Interfaces.WeatherForecast;
using HotelsInCities.Infrastructure.WeatherForecast.Services;
using HotelsInCities.Services.Services.Implementation;

namespace HotelsInCities.ServicesConfiguration
{
    public static class ServiceCollectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<CityService>();
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWeatherForeacstService, WeatherForecastService>();
        }
    }
}
