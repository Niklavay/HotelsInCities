
using HotelsInCities.Domain.Core.Entities;
using HotelsInCities.Domain.Interfaces.Repositories.Generic;

namespace HotelsInCities.Domain.Interfaces.Repositories
{
    public interface IHotelRepository : IGenericRepository<Hotel, int>
    {
    }
}
