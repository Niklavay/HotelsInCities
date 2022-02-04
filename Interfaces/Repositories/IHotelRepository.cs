using Core;
using HotelsInCities.Domain.Core;
using Interfaces.Generic;

namespace Interfaces.Repositories
{
    public interface IHotelRepository : IGenericRepository<Hotel, int>
    {
    }
}
