using Core;
using HotelsInCities.Infrastructure.Interfaces.Repositories.UnitOfWork;
using HotelsInCities.Services.Intefaces.Interfaces;
using HotelsInCities.Services.Intefaces.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsInCities.Services.Intefaces.DTO_s.City;
using AutoMapper;
using HotelsInCities.Domain.Core;

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

        public async Task Create(CityDTO cityDTO)
        {
            var newCity = new City(cityDTO.Name, cityDTO.Population, cityDTO.Latitude, cityDTO.Longitude);

            await _unitOfWork.CityRepository.Insert(newCity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CityDTO> GetById(int id)
        {
            var city = await _unitOfWork.CityRepository.GetById(id);
            return _mapper.Map<CityDTO>(city);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CityRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<FullCityDTO>> GetAll()
        {
            var cities = await _unitOfWork.CityRepository.GetAll();
            return _mapper.Map<IEnumerable<FullCityDTO>>(cities);
        }

        public async Task<IEnumerable<CityForCreationHotelDTO>> GetAllForHotelCreation()
        {
            var result = await _unitOfWork.CityRepository.GetAll(include: c => c.Include(c => c.Hotels));
            return _mapper.Map<List<City>, IEnumerable<CityForCreationHotelDTO>>(result);
        }
        public async Task Update(int id, CityDTO cityDTO)
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
