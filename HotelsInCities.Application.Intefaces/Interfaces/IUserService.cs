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
        Task Create(CreateUserDto user);
        Task<UserDto> GetById(int id);
        Task Delete(int id);
    }
}
