using System;
using System.Collections.Generic;
using Service.Dtos;
using System.Threading.Tasks;

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
