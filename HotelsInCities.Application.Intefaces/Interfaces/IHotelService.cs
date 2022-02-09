using HotelsInCities.Application.Intefaces.Dtos.Hotel;

namespace HotelsInCities.Application.Intefaces.Interfaces
{
    public interface IHotelService
    {
        Task Create(HotelDto hotelDTO);
        Task<HotelDto> GetById(int id);
        Task<IEnumerable<HotelDto>> GetAll();
        Task<IEnumerable<FullHotelDto>> GetAllByCityId(int id);
        Task Update(int id, HotelDto hotelDTO);
        Task Delete(int id);
    }
}
