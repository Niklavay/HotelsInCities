using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Services.Intefaces.Interfaces
{
    public interface IHotelService
    {
        Task<Hotel> GetById(int id);
        Task<IEnumerable<Hotel>> GetAll();
        Task Update(Hotel hotel);
        Task Delete(int id);
    }
}
