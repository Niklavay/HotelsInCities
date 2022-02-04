using Core;
using HotelsInCities.Infrastructure.Interfaces.Repositories.UnitOfWork;
using HotelsInCities.Services.Intefaces.DTO_s;
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

        public async Task Create(HotelDTO hotelDTO)
        {
            var hotel = new Hotel(hotelDTO.Name, hotelDTO.HotelRating, hotelDTO.CityId, hotelDTO.RoomsCount, hotelDTO.Comment);
            await _unitOfWork.HotelRepository.Insert(hotel);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Hotel> GetById(int id)
        {
           return await _unitOfWork.HotelRepository.GetById(id);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.HotelRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetAll()
        {
            return await _unitOfWork.HotelRepository.GetAll();
        }
        public async Task<IEnumerable<Hotel>> GetAllByCityId(int id)
        {
            return await _unitOfWork.HotelRepository.Get(filter: h => h.CityId == id);
        }
        public async Task Update(int id, HotelDTO hotelDTO)
        {
            if (hotelDTO != null)
            {
                var hotel = await _unitOfWork.HotelRepository.GetById(id);

                hotel.ChangeInfo(hotelDTO.Name, hotelDTO.HotelRating, hotelDTO.CityId, hotelDTO.RoomsCount, hotelDTO.Comment);

                _unitOfWork.HotelRepository.Update(hotel);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
