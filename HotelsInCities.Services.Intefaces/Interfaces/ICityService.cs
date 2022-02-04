using Core;
using HotelsInCities.Services.Intefaces.DTO_s.City;

namespace HotelsInCities.Services.Intefaces.Interfaces
{
    public interface ICityService
    {
        Task Create(CityDTO city);
        Task<CityDTO> GetById(int id);
        Task<IEnumerable<FullCityDTO>> GetAll();
        Task<IEnumerable<CityForCreationHotelDTO>> GetAllForHotelCreation();
        Task Update(int id, CityDTO city);
        Task Delete(int id);
    }
}