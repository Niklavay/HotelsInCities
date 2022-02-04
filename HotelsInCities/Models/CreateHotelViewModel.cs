

using Core;
using HotelsInCities.Services.Intefaces.DTO_s;

namespace HotelsInCities.Models
{
    public class CreateHotelViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public HotelDTO Hotel { get; set; }
    }
}
