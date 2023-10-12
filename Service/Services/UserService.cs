using System;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Exceptions;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;

        public UserService(IMapper mapper, IUserRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var user = await GetByEmailAsync(userDto.Email);

            if (user != null) {
                throw new DomainException("Email já registrado!");
            }

            var entity = mapper.Map<User>(userDto);

            if (!entity.Validate())
              throw new DomainException(entity.Errors);

            var created = await repository.InsertAsync(entity);
            
            return mapper.Map<UserDto>(created);
        }

        public async Task<IList<UserDto>> GetAllAsync()
        {
            var users = await repository.SelectAllAsync();
            return mapper.Map<IList<UserDto>>(users);
        }

        public async Task<UserDto> GetAsync(long id)
        {
            var user = await repository.SelectAsync(id);
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await repository.GetByEmailAsync(email);
            return mapper.Map<UserDto>(user);
        }

        public async Task RemoveAsync(UserDto obj)
        {
            await repository.DeleteAsync(mapper.Map<User>(obj));
        }

        public async Task RemoveAsync(long id)
        {
            var obj = await GetAsync(id);
             await repository.DeleteAsync(mapper.Map<User>(obj));
        }

        public async Task<IList<UserDto>> SearchByEmailAsync(string email)
        {
            var user = await repository.SearchByEmailAsync(email);
            return mapper.Map<List<UserDto>>(user);
        }

        public async Task<IList<UserDto>> SearchByNameAsync(string name)
        {
            var user = await repository.SearchByNameAsync(name);
            return mapper.Map<List<UserDto>>(user);
        }

        public async Task<UserDto> UpdateAsync(UserDto userDto)
        {
            var user = await repository.UpdateAsync(mapper.Map<User>(userDto));
            return mapper.Map<UserDto>(user);
        }
    }
}
