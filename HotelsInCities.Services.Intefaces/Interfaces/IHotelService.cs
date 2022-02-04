using Core;
using HotelsInCities.Services.Intefaces.DTO_s;
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
        Task<Hotel> GetById(int id);
        Task<IEnumerable<Hotel>> GetAll();
        Task<IEnumerable<Hotel>> GetAllByCityId(int id);
        Task Update(int id, HotelDTO hotelDTO);
        Task Delete(int id);
    }
}
