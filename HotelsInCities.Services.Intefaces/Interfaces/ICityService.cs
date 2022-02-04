using Core;
using HotelsInCities.Services.Intefaces.DTO_s;

namespace HotelsInCities.Services.Intefaces.Interfaces
{
    public interface ICityService
    {
        Task Create(CityDTO city);
        Task<City> GetById(int id);
        Task<IEnumerable<City>> GetAll();
        Task Update(int id, CityDTO city);
        Task Delete(int id);
    }
}