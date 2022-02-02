using DataAccess;
using DataAccess.Repositories;
using HotelsInCities.Infrastructure.Interfaces.Repositories.UnitOfWork;
using Interfaces;
using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Infrastructure.DataAccess.Repositories.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private ICityRepository _cityRepository;

        private IHotelRepository _hotelRepository;


        private HICDbContext _context;

        public UnitOfWork(HICDbContext context)
        {
            _context = context;
        }

        public ICityRepository CityRepository
        {
            get { return _cityRepository ??= new CityRepository(_context); }
        }

        public IHotelRepository HotelRepository
        {
            get { return _hotelRepository ??= new HotelRepository(_context); }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
