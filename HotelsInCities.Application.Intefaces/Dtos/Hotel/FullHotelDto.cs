using HotelsInCities.Domain.Common.Enums;

namespace HotelsInCities.Application.Intefaces.Dtos.Hotel
{
    public class FullHotelDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public HotelRating HotelRating { get;  set; }
        public int RoomsCount { get;  set; }
        public string Comment { get;  set; }
    }
}
