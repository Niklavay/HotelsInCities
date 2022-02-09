using HotelsInCities.Application.Intefaces.Dtos.City;

namespace HotelsInCities.Application.Intefaces.Interfaces
{
    public interface ICityService
    {
        Task Create(CityDto city);
        Task<CityDto> GetById(int id);
        Task<IEnumerable<FullCityDto>> GetAll();
        Task<IEnumerable<CityForCreationHotelDto>> GetAllForHotelCreation();
        Task Update(int id, CityDto city);
        Task Delete(int id);
    }
}