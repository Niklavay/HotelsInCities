﻿using AutoMapper;
using Core;
using HotelsInCities.Domain.Core;
using HotelsInCities.Services.Intefaces.DTO_s.City;

namespace HotelsInCities.Services.Services.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>()
                .ForMember(cdto => cdto.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(cdto => cdto.Population,
                    opt => opt.MapFrom(src => src.Population))
                .ForMember(cdto => cdto.Latitude,
                    opt => opt.MapFrom(src => src.Latitude))
                .ForMember(cdto => cdto.Longitude,
                    opt => opt.MapFrom(src => src.Longitude));
            CreateMap<City, FullCityDTO>()
                .ForMember(fcdto => fcdto.Id,
                    opt => opt.MapFrom(src => src.Id))
                 .ForMember(fcdto => fcdto.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(fcdto => fcdto.Population,
                    opt => opt.MapFrom(src => src.Population))
                .ForMember(fcdto => fcdto.Latitude,
                    opt => opt.MapFrom(src => src.Latitude))
                .ForMember(fcdto => fcdto.Longitude,
                    opt => opt.MapFrom(src => src.Longitude)); ;
            CreateMap<City, CityForCreationHotelDTO>();
        }
    }
}
