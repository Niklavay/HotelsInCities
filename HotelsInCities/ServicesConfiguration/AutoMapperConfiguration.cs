using AutoMapper;
using HotelsInCities.Services.Services.MappingProfiles;

namespace HotelsInCities.ServicesConfiguration
{
    public static class AutoMapperConfiguration
    {
        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CityProfile());
               

            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
