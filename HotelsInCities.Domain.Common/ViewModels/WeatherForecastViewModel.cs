using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Domain.Common.ViewModels
{
    public class WeatherForecastViewModel
    {
        public int Lat { get; set; }
        public int Lon { get; set; }
        public string Timezone { get; set; }
        public CurrentWeather Current { get; set; }
    }

    public class CurrentWeather
    {
        public int Clouds { get; set; }    
        public string WindSpeed { get; set; }
        public List<Weather> Weather { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }
}
