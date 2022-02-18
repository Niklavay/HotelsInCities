using AutoMapper;
using HotelsInCities.Application.Services.MappingProfiles;
using HotelsInCities.Services.Services.MappingProfiles;

namespace HotelsInCities.ServicesConfiguration
{
    public static class AutoMapperConfiguration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CityProfile());
                mc.AddProfile(new HotelProfile());
                mc.AddProfile(new UserProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
