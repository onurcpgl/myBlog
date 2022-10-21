using Application.DataTransferObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<bool> saveUser(UserDto userDto);
        Task<User> getCategoryById(int id);
        Task<User> loadByUser(LoginDto loginDto);
    }
}
