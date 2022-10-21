using Application.DataTransferObject;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;

        public UserService(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
        }

        public Task<User> getCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> loadByUser(LoginDto loginDto)
        {
            var user = await _userReadRepository.GetWhereWithInclude(x => x.emailAdress == loginDto.emailAdress && x.password == loginDto.password,true).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> saveUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.createdDate = DateTime.UtcNow;
            user.role = "user";
            var result = await _userWriteRepository.AddAsync(user);
            if (!result)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
