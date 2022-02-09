using HotelsInCities.Domain.Core.Entities;
using HotelsInCities.Domain.Interfaces.Repositories;
using HotelsInCities.Infrastructure.DataAccess.Repositories.Generic;

namespace DataAccess.Repositories
{
    public class HotelRepository : GenericRepository<Hotel, int>, IHotelRepository
    {
        public HotelRepository(HICDbContext context) : base(context)
        { }
    }
}
