using Core;
using HotelsInCities.Infrastructure.Interfaces.Repositories.UnitOfWork;
using HotelsInCities.Services.Intefaces.Interfaces;

namespace HotelsInCities.Services.Services.Implementation
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Hotel> GetById(int id)
        {
           return await _unitOfWork.HotelRepository.GetById(id);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.HotelRepository.Delete(id);
        }

        public async Task<IEnumerable<Hotel>> GetAll()
        {
            return await _unitOfWork.HotelRepository.GetAll();
        }

        public async Task Update(Hotel hotel)
        {
            if (hotel != null)
            {
                _unitOfWork.HotelRepository.Update(hotel);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
