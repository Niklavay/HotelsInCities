using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Infrastructure.WeatherForecast.ViewModels
{
    public class WeatherForecastViewModel
    {
        public int Temperature { get; set; }
        public int FeelsLikeTemperature { get; set; }
        public int WindSpeed { get; set; }
        public int Clouds { get; set; }
    }
}
