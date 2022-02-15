using AutoMapper;
using HotelsInCities.Application.Intefaces.Dtos.User;
using HotelsInCities.Application.Intefaces.Interfaces;
using HotelsInCities.Domain.Core.Entities;
using HotelsInCities.Domain.Interfaces.Repositories.UnitOfWork;

namespace HotelsInCities.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(CreateUserDto userDto)
        {

            var newUser = new User(userDto.Name, userDto.Login, userDto.Password);

            await _unitOfWork.UserRepository.Insert(newUser);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
