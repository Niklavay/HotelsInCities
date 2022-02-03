using HotelsInCities.Infrastructure.WeatherForecast.Services;
using HotelsInCities.Infrastructure.WeatherForecast.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Infrastructure.WeatherForecast.Interfaces
{
    public interface IWeatherForeacstService
    {
        Task<OpenWeatherResponse> GetWeatherForecast(int longitude, int latitude);
    }
}
