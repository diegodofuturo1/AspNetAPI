using System;
using Domain.ViewModels;
using Application.Token;
using Service.Interfaces;
using System.Threading.Tasks;
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
    private readonly IUserService userService;

    public AuthController(IConfiguration configuration, ITokenService tokenService, IUserService userService)
    {
      this.configuration = configuration;
      this.tokenService = tokenService;
      this.userService = userService;
    }

    [HttpPost("signin")]

    public async Task<IActionResult> SignIn([FromBody] SigninViewModel loginViewModel)
    {
      var user = await userService.GetByEmailAsync(loginViewModel.Login);

      if (user == null)
        return StatusCode(404, new ResultViewModel()
        {
          Message = "Usuário não encontrado!",
          Success = false,
          Data = null
        });

      if (loginViewModel.Password == user.Password)
        return Ok(new ResultViewModel
        {
          Message = "Usuário autenticado com sucesso!",
          Success = true,
          Data = new TokenViewModel
          {
            Name = user.Name,
            Email = user.Email,
            Token = tokenService.GenerateToken(user.Id),
            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(configuration["Jwt:HoursToExpire"]))
          }
        });
      else
        return StatusCode(401, new ResultViewModel()
        {
          Message = "Usuário não autenticado!",
          Success = false,
          Data = null
        });
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignupViewModel loginViewModel)
    {
      try
      {
        var dto = loginViewModel.ToDomain();

        var user = await userService.CreateAsync(dto);

        if (user != null)
          return await SignIn(new SigninViewModel(user));

        return Problem();
      }
      catch (Exception exception)
      {

        return StatusCode(400, new ResultViewModel()
        {
          Message = exception.Message,
          Success = false,
          Data = null
        });
      }

    }
  }
}
