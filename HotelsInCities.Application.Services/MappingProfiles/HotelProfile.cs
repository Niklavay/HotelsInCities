using AutoMapper;
using HotelsInCities.Application.Intefaces.Dtos.Hotel;
using HotelsInCities.Domain.Core.Entities;

namespace HotelsInCities.Services.Services.MappingProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>();
            CreateMap<Hotel, FullHotelDto>();
        }
    }
}
