using Core.Enums;

namespace HotelsInCities.Services.Intefaces.DTO_s.Hotel
{
    public class HotelDTO
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Comment { get; set; }
        public HotelRating HotelRating { get; set; }
        public int RoomsCount { get; set; }
    }
}
