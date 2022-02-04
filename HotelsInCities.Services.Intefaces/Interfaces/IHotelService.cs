using Core;
using HotelsInCities.Services.Intefaces.DTO_s;
using HotelsInCities.Services.Intefaces.DTO_s.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Services.Intefaces.Interfaces
{
    public interface IHotelService
    {
        Task Create(HotelDTO hotelDTO);
        Task<HotelDTO> GetById(int id);
        Task<IEnumerable<HotelDTO>> GetAll();
        Task<IEnumerable<HotelDTO>> GetAllByCityId(int id);
        Task Update(int id, HotelDTO hotelDTO);
        Task Delete(int id);
    }
}
