using Microsoft.EntityFrameworkCore;
using HotelsInCities.Application.Intefaces.Dtos.City;
using AutoMapper;
using HotelsInCities.Domain.Core;
using HotelsInCities.Application.Intefaces.Interfaces;
using HotelsInCities.Domain.Core.Entities;
using HotelsInCities.Domain.Interfaces.Repositories.UnitOfWork;

namespace HotelsInCities.Services.Services.Implementation
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(CityDto cityDTO)
        {
            var newCity = new City(cityDTO.Name, cityDTO.Population, cityDTO.Latitude, cityDTO.Longitude);

            await _unitOfWork.CityRepository.Insert(newCity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CityDto> GetById(int id)
        {
            var city = await _unitOfWork.CityRepository.GetById(id);
            return _mapper.Map<CityDto>(city);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CityRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<FullCityDto>> GetAll()
        {
            var cities = await _unitOfWork.CityRepository.GetAll();
            return _mapper.Map<IEnumerable<FullCityDto>>(cities);
        }

        public async Task<IEnumerable<CityForCreationHotelDto>> GetAllForHotelCreation()
        {
            var result = await _unitOfWork.CityRepository.GetAll(include: c => c.Include(c => c.Hotels));
            return _mapper.Map<List<City>, IEnumerable<CityForCreationHotelDto>>(result);
        }
        public async Task Update(int id, CityDto cityDTO)
        {
            if (cityDTO != null)
            {
                var city = await _unitOfWork.CityRepository.GetById(id);

                city.ChangeInfo(cityDTO.Name, cityDTO.Population,cityDTO.Latitude, cityDTO.Longitude);

                _unitOfWork.CityRepository.Update(city);
                await _unitOfWork.SaveChangesAsync();
            }
        }

    }
}
