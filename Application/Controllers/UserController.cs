using AutoMapper;
using Service.Dtos;
using Service.Interfaces;
using System.Threading.Tasks;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    [ApiController]
    [Route("user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService service;

        public UserController(IMapper mapper, IUserService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAsync()
        {
            var users = await service.GetAllAsync();
            return Ok(new ResultViewModel()
            {
                Message = "Usuários obtidos com sucesso",
                Success = true,
                Data = users
            });
        }

        [HttpGet]
        [Route("get-by-id")]

        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var user = await service.GetAsync(id);
            return Ok(new ResultViewModel()
            {
                Message = "Usuário obtido com sucesso",
                Success = true,
                Data = user
            });
        }

        [HttpGet]
        [Route("get-by-email")]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            var user = await service.GetByEmailAsync(email);
            return Ok(new ResultViewModel()
            {
                Message = "Usuário obtido com sucesso",
                Success = true,
                Data = user
            });
        }

        [HttpGet]
        [Route("search-by-email")]
        public async Task<IActionResult> SearchByEmailAsync(string email)
        {
            var users = await service.SearchByEmailAsync(email);
            return Ok(new ResultViewModel()
            {
                Message = "Usuário obtido com sucesso",
                Success = true,
                Data = users
            });
        }

        [HttpGet]
        [Route("search-by-name")]
        public async Task<IActionResult> SearchByNameAsync(string name)
        {
            var users = await service.SearchByEmailAsync(name);
            return Ok(new ResultViewModel()
            {
                Message = "Usuário obtido com sucesso",
                Success = true,
                Data = users
            });
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserViewModel userViewModel)
        {
            var userDto = mapper.Map<UserDto>(userViewModel);
            var userCreated = await service.CreateAsync(userDto);

            return Ok(new ResultViewModel()
            {
                Message = "Usuário criado com sucesso!",
                Success = true,
                Data = userCreated
            });
        }

        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> PutAsync([FromBody] UpdateUserViewModel userViewModel)
        {
            var userDto = mapper.Map<UserDto>(userViewModel);
            var userUpdated = await service.UpdateAsync(userDto);

            return Ok(new ResultViewModel()
            {
                Message = "Usuário atualizado com sucesso!",
                Success = true,
                Data = userUpdated
            });
        }



        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await service.RemoveAsync(id);

            return Ok(new ResultViewModel()
            {
                Message = "Usuário deletado com sucesso!",
                Success = true
            });
        }
    }
}
