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

        public async Task<bool> Create(CreateUserDto userDto)
        {
            if(!await AlreadyExist(userDto.Email))
            {
                try
                {
                    var newUser = new User(userDto.Email, userDto.Password);

                    await _unitOfWork.UserRepository.Insert(newUser);
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {

                    throw new ArgumentException(e.Message);
                }
                
            }
            return false;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = (await _unitOfWork.UserRepository.Get(u => u.Email == email)).FirstOrDefault();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> AlreadyExist(string email)
        {
            return (await _unitOfWork.UserRepository.Get(u => u.Email == email)).Any();
        }
    }
}
