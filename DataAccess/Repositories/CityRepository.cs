using Core;
using HotelsInCities.Domain.Core;
using HotelsInCities.Infrastructure.DataAccess.Repositories.Generic;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CityRepository : GenericRepository<City, int>, ICityRepository
    {
        public CityRepository(HICDbContext context) : base(context)
        { }
    }
}
