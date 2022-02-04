using AutoMapper;
using Core;
using HotelsInCities.Domain.Core;
using HotelsInCities.Services.Intefaces.DTO_s.Hotel;

namespace HotelsInCities.Services.Services.MappingProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDTO>();
            CreateMap<Hotel, FullHotelDTO>();
        }
    }
}
