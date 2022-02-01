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
    }
}
