using Core;

namespace HotelsInCities.Services.Intefaces.Interfaces
{
    public interface ICityService
    {
        Task<City> GetById(int id);
        Task<IEnumerable<City>> GetAll();
        Task Update(City city);
        Task Delete(int id);
    }
}