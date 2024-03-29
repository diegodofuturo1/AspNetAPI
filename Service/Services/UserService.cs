﻿using System;
using AutoMapper;
using Service.Dtos;
using Domain.Entities;
using Service.Interfaces;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;

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
                throw new Exception("Email já registrado!");
            }

            var created = await repository.CreateAsync(mapper.Map<User>(userDto));

            if (!created.IsValid)
                return default;
            
            created.SetPassword("***********");
            return mapper.Map<UserDto>(created);
        }

        public async Task<IList<UserDto>> GetAllAsync()
        {
            var users = await repository.GetAllAsync();
            return mapper.Map<IList<UserDto>>(users);
        }

        public async Task<UserDto> GetAsync(long id)
        {
            var user = await repository.GetAsync(id);
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await repository.GetByEmailAsync(email);
            return mapper.Map<UserDto>(user);
        }

        public async Task RemoveAsync(long id)
        {
            await repository.RemoveAsync(id);
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
