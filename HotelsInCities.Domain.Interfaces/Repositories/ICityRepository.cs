using HotelsInCities.Domain.Core.Entities;
using HotelsInCities.Domain.Interfaces.Repositories.Generic;

namespace HotelsInCities.Domain.Interfaces.Repositories
{
    public interface ICityRepository : IGenericRepository<City, int>
    {
    }
}