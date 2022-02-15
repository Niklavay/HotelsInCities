using HotelsInCities.Domain.Interfaces.WeatherForecast;
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
        public async Task<IActionResult> Index(int id)
        {
            var result = await _weatherForecastService.GetWeatherForecast(id);
            return View(result);
        }
    }
}
