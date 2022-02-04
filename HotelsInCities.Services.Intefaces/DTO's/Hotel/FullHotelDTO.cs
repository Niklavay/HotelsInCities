using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Services.Intefaces.DTO_s.Hotel
{
    public class FullHotelDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public HotelRating HotelRating { get;  set; }
        public int RoomsCount { get;  set; }
        public string Comment { get;  set; }
    }
}
