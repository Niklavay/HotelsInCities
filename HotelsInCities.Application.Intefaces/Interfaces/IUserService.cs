using HotelsInCities.Application.Intefaces.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Application.Intefaces.Interfaces
{
    public interface IUserService
    {
        Task<bool> Create(CreateUserDto userDto);
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByEmail(string email);
        Task<bool> AlreadyExist(string email);

    }
}
