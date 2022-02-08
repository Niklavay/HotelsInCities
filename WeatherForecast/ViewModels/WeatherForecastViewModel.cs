using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Infrastructure.WeatherForecast.ViewModels
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
        public string Main { get; set; }    
        public string Description { get; set; }
    }
}
