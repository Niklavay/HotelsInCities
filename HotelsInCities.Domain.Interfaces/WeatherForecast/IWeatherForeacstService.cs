using HotelsInCities.Domain.Common.ViewModels;

namespace HotelsInCities.Domain.Interfaces.WeatherForecast
{
    public interface IWeatherForeacstService
    {
        Task<WeatherForecastViewModel> GetWeatherForecast(int cityId);
    }
}
