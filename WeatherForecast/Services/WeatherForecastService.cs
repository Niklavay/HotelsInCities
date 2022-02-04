using HotelsInCities.Infrastructure.WeatherForecast.Interfaces;
using HotelsInCities.Infrastructure.WeatherForecast.ResponseEntities;
using HotelsInCities.Infrastructure.WeatherForecast.ViewModels;
using HotelsInCities.Services.Intefaces.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Infrastructure.WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForeacstService
    {
        private readonly IConfiguration _configuration;
        private readonly ICityService _cityService;

        public WeatherForecastService(IConfiguration configuration, ICityService cityService)
        {
            _cityService = cityService;
            _configuration = configuration;
        }
        public async Task<WeatherForecastResponse> GetWeatherForecast(int cityId)
        {
            var city = await _cityService.GetById(cityId);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["WeatherForecastUri:Uri"]);
                var response = await client.GetAsync($"/data/2.5/onecall?lat={city.Latitude}&lon={city.Longitude}&exclude=daily&appid={_configuration["WeatherForecastAPIKey:Key"]}");
                response.EnsureSuccessStatusCode();
                
                var stringResult = await response.Content.ReadAsStringAsync();

                var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);

                return new WeatherForecastResponse { City = rawWeather.Name,
                                                     Temp = rawWeather.Main.Temp,
                                                     Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)) 
                };
            }
        }
    }
   

   

    
}
