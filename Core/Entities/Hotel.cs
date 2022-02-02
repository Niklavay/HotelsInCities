using Core.Enums;
using Core.Generic;

namespace Core
{
    public  class Hotel : IGenericEntity<int>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public HotelRating HotelRating { get; private set; }
        public int CityId { get; private set;}
        public City City { get; private set; }
        public int RoomsCount { get; private set; } 
        public string Comment { get; private set; }

        public Hotel() { }

        public Hotel(
            string name,
            HotelRating hotelRating,
            int cityId,
            int roomsCount,
            string comment
            )
        {
            Name = name;
            HotelRating = hotelRating;
            CityId = cityId;
            RoomsCount = roomsCount;
            Comment = comment;
        }

        public void ChangeHotelName(string name)
        {
            if(name != null)
                Name = name;
        }
        public void ChangeHotelRating(HotelRating hotelRating)
        {
            HotelRating = hotelRating;
        }

        public void ChangeCity(int cityId)
        {
            if(cityId >= 0 && CityId != cityId)
                CityId = cityId;
        }

        public void ChangeAmountOfRooms(int roomsCount)
        {
            if(roomsCount > 0)
                RoomsCount = roomsCount;
        }

        public void ChangeComment(string comment)
        {
            if(comment != null)
                Comment = comment;
        }
    }
}
