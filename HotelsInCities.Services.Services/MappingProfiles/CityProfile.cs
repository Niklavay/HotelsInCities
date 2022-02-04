using AutoMapper;
using Core;
using HotelsInCities.Domain.Core;
using HotelsInCities.Services.Intefaces.DTO_s.City;

namespace HotelsInCities.Services.Services.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<City, FullCityDTO>();
            CreateMap<City, CityForCreationHotelDTO>();
        }
    }
}
