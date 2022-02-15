using AutoMapper;
using HotelsInCities.Application.Intefaces.Dtos.Hotel;
using HotelsInCities.Application.Intefaces.Interfaces;
using HotelsInCities.Domain.Core.Entities;
using HotelsInCities.Domain.Interfaces.Repositories.UnitOfWork;

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

        public async Task Create(HotelDto hotelDTO)
        {
            var hotel = new Hotel(hotelDTO.Name, hotelDTO.HotelRating, hotelDTO.CityId, hotelDTO.RoomsCount, hotelDTO.Comment);
            await _unitOfWork.HotelRepository.Insert(hotel);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<HotelDto> GetById(int id)
        {
            var hotel = await _unitOfWork.HotelRepository.GetById(id);
            return _mapper.Map<Hotel, HotelDto>(hotel);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.HotelRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelDto>> GetAll()
        {
            var hotels = await _unitOfWork.HotelRepository.GetAll();
            return _mapper.Map<List<Hotel>,IEnumerable<HotelDto>>(hotels);
        }
        public async Task<IEnumerable<FullHotelDto>> GetAllByCityId(int id)
        {
            var hotels = await _unitOfWork.HotelRepository.Get(filter: h => h.CityId == id);
            return _mapper.Map<List<Hotel>, IEnumerable<FullHotelDto>>(hotels);
        }
        public async Task Update(int id, HotelDto hotelDTO)
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
