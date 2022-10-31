using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Token;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Application.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;

        public AuthController(IConfiguration configuration, ITokenService tokenService)
        {
            this.configuration = configuration;
            this.tokenService = tokenService;
        }

        [HttpPost]

        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            var tokenLogin = configuration["Jwt:Login"];
            var tokenPassword = configuration["Jwt:Password"];

            if (loginViewModel.Login == tokenLogin && loginViewModel.Password == tokenPassword)
                return Ok(new ResultViewModel
                {
                    Message = "Usuário autenticado com sucesso!",
                    Success = true,
                    Data = new
                    {
                        Token = tokenService.GenerateToken(),
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
    }
}
