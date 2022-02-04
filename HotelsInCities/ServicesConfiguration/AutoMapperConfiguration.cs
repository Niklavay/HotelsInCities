using AutoMapper;
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
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
