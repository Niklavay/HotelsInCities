using HotelsInCities.Infrastructure.WeatherForecast.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelsInCities.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForeacstService _weatherForecastService;

        public WeatherForecastController(IWeatherForeacstService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }
        public async Task<IActionResult> Index(int cityId)
        {
            var result = await _weatherForecastService.GetWeatherForecast(cityId);
            return View(result);
        }
    }
}
