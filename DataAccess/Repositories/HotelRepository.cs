using Core;
using HotelsInCities.Domain.Core;
using HotelsInCities.Infrastructure.DataAccess.Repositories.Generic;
using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class HotelRepository : GenericRepository<Hotel, int>, IHotelRepository
    {
        public HotelRepository(HICDbContext context) : base(context)
        { }
    }
}
