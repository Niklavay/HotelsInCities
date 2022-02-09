using HotelsInCities.Domain.Core.Entities;
using HotelsInCities.Domain.Interfaces.Repositories;
using HotelsInCities.Infrastructure.DataAccess.Repositories.Generic;

namespace DataAccess.Repositories
{
    public class CityRepository : GenericRepository<City, int>, ICityRepository
    {
        public CityRepository(HICDbContext context) : base(context)
        { }
    }
}
