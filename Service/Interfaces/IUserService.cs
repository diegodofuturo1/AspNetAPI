using System;
using Domain.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task RemoveAsync(long id);
        Task<UserDto> GetAsync(long id);
        Task<IList<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(UserDto UserDto);
        Task<UserDto> UpdateAsync(UserDto UserDto);
        Task<UserDto> GetByEmailAsync(string email);
        Task<IList<UserDto>> SearchByNameAsync(string name);
        Task<IList<UserDto>> SearchByEmailAsync(string email);
    }
}
