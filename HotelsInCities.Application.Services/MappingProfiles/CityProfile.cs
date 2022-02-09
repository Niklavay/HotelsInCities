using AutoMapper;
using HotelsInCities.Application.Intefaces.Dtos.City;
using HotelsInCities.Domain.Core.Entities;

namespace HotelsInCities.Services.Services.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>()/*
                .ForMember(cdto => cdto.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(cdto => cdto.Population,
                    opt => opt.MapFrom(src => src.Population))
                .ForMember(cdto => cdto.Latitude,
                    opt => opt.MapFrom(src => src.Latitude))
                .ForMember(cdto => cdto.Longitude,
                    opt => opt.MapFrom(src => src.Longitude))*/;
            CreateMap<City, FullCityDto>() ;
            CreateMap<City, CityForCreationHotelDto>();
        }
    }
}
