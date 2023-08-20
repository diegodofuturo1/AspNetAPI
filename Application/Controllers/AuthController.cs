using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Token;
using Application.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Dtos;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly IUserService userService;

        public AuthController(IMapper mapper, IConfiguration configuration, ITokenService tokenService, IUserService userService)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.userService = userService;
        }

        [HttpPost("signin")]

        public async Task<IActionResult> SignIn([FromBody] LoginViewModel loginViewModel)
        {
            var user = await userService.GetByEmailAsync(loginViewModel.Login);

            if (user == null)
              throw new Exception("Usuário não autenticado!");

            if (loginViewModel.Password == user.Password)
                return Ok(new ResultViewModel
                {
                    Message = "Usuário autenticado com sucesso!",
                    Success = true,
                    Data = new
                    {
                        Token = tokenService.GenerateToken(user.Id),
                        TokenExpires = DateTime.UtcNow.AddHours(int.Parse(configuration["Jwt:HoursToExpire"]))
                    }
                });
            else
                return StatusCode(401, new ResultViewModel() { 
                    Message = "Usuário não autenticado!",
                    Success = false,
                    Data = null
                });
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] LoginViewModel loginViewModel)
        {
          var dto = loginViewModel.ToDomain();

          var user = await userService.CreateAsync(dto);

          if (user != null)
            return await SignIn(new LoginViewModel(user));

          return Problem();
        }
    }
}
