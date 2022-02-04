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

namespace HotelsInCities.Services.Services.Implementation
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(CityDTO cityDTO)
        {
            var newCity = new City(cityDTO.Name, cityDTO.Population, cityDTO.Latitude, cityDTO.Longitude);

            await _unitOfWork.CityRepository.Insert(newCity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _unitOfWork.CityRepository.GetById(id);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CityRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            var result = await _unitOfWork.CityRepository.GetAll(include: c => c.Include(c => c.Hotels));
            return result;
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
