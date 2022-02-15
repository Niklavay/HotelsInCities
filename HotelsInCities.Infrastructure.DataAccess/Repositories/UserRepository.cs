using HotelsInCities.Domain.Core.Entities;
using HotelsInCities.Domain.Interfaces.Repositories;
using HotelsInCities.Infrastructure.DataAccess.Contexts;
using HotelsInCities.Infrastructure.DataAccess.Repositories.Generic;

namespace HotelsInCities.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(HICDbContext context) : base(context)
        { }
    }
}
