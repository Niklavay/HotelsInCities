using AutoMapper;
using Core;
using HotelsInCities.Domain.Core;
using HotelsInCities.Infrastructure.Interfaces.Repositories.UnitOfWork;
using HotelsInCities.Services.Intefaces.DTO_s;
using HotelsInCities.Services.Intefaces.DTO_s.Hotel;
using HotelsInCities.Services.Intefaces.Interfaces;

namespace HotelsInCities.Services.Services.Implementation
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HotelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(HotelDTO hotelDTO)
        {
            var hotel = new Hotel(hotelDTO.Name, hotelDTO.HotelRating, hotelDTO.CityId, hotelDTO.RoomsCount, hotelDTO.Comment);
            await _unitOfWork.HotelRepository.Insert(hotel);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetById(int id)
        {
            var hotel = await _unitOfWork.HotelRepository.GetById(id);
            return _mapper.Map<Hotel,HotelDTO>(hotel);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.HotelRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelDTO>> GetAll()
        {
            var hotels = await _unitOfWork.HotelRepository.GetAll();
            return _mapper.Map<List<Hotel>,IEnumerable<HotelDTO>>(hotels);
        }
        public async Task<IEnumerable<FullHotelDTO>> GetAllByCityId(int id)
        {
            var hotels = await _unitOfWork.HotelRepository.Get(filter: h => h.CityId == id);
            return _mapper.Map<List<Hotel>, IEnumerable<FullHotelDTO>>(hotels);
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
