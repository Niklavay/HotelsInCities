﻿using HotelsInCities.Application.Intefaces.Interfaces;
using HotelsInCities.Infrastructure.WeatherForecast.Interfaces;
using HotelsInCities.Infrastructure.WeatherForecast.ResponseEntities;
using HotelsInCities.Infrastructure.WeatherForecast.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
        public async Task<WeatherForecastViewModel> GetWeatherForecast(int cityId)
        {
            var city = await _cityService.GetById(cityId);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["WeatherForecastUri:Uri"]);
                var response = await client.GetAsync($"/data/2.5/onecall?lat={city.Latitude}&lon={city.Longitude}&appid={_configuration["WeatherForecastAPIKey:Key"]}");
                response.EnsureSuccessStatusCode();
                
                var stringResult = await response.Content.ReadAsStringAsync();

               
                var rawWeather = JsonConvert.DeserializeObject<WeatherForecastViewModel>(stringResult);

                return rawWeather;
            }
        }
    }
   

   

    
}