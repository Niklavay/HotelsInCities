using Interfaces;
using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Infrastructure.Interfaces.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository CityRepository { get; }
        IHotelRepository HotelRepository { get; }
        Task SaveChangesAsync();
    }
}
