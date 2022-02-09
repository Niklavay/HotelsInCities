using HotelsInCities.Domain.Core.Enums;

namespace HotelsInCities.Application.Intefaces.Dtos.Hotel
{
    public class HotelDto
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Comment { get; set; }
        public HotelRating HotelRating { get; set; }
        public int RoomsCount { get; set; }
    }
}
