using DataAccess;
using DataAccess.Repositories;
using HotelsInCities.Domain.Interfaces.Repositories;
using HotelsInCities.Domain.Interfaces.Repositories.UnitOfWork;

namespace HotelsInCities.Infrastructure.DataAccess.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
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
