using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Infrastructure.WeatherForecast.ResponseEntities
{
    public class WeatherForecastResponse
    {
        public string Temp { get; set; }
        public string Summary { get; set; }
        public string City  { get; set; }
    }
}
