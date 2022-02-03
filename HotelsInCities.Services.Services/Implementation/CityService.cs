using Core;
using HotelsInCities.Infrastructure.Interfaces.Repositories.UnitOfWork;
using HotelsInCities.Services.Intefaces.Interfaces;
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

        public async Task<City> GetById(int id)
        {
            return await _unitOfWork.CityRepository.GetById(id);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CityRepository.Delete(id);
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _unitOfWork.CityRepository.GetAll(include: c => c.Include(c => c.Hotels));
        }

        public async Task Update(City city)
        {
            if (city != null)
            {
                _unitOfWork.CityRepository.Update(city);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
