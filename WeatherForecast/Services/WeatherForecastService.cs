using HotelsInCities.Infrastructure.WeatherForecast.Interfaces;
using HotelsInCities.Infrastructure.WeatherForecast.ViewModels;
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
        readonly IConfiguration _configuration;

        public WeatherForecastService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<OpenWeatherResponse> GetWeatherForecast(int longitude, int latitude)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["WeatherForecastUri:Uri"]);
                var response = await client.GetAsync($"/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=daily&appid={_configuration["WeatherForecastAPIKey:Key"]}");
                response.EnsureSuccessStatusCode();
                
                var stringResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
            }
        }
    }
    public class OpenWeatherResponse
    {
        public string Name { get; set; }

        public IEnumerable<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
    }
}
