using AutoMapper;
using Domain.Entities;
using Service.Interfaces;
using Domain.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
  [ApiController]
  [Route("wallet")]
  public class WalletController : ControllerBase
  {
    private readonly IMapper mapper;
    private readonly IWalletService service;

    public WalletController(IMapper mapper, IWalletService service)
    {
      this.mapper = mapper;
      this.service = service;
    }

    [HttpGet]
    [Route("get-history/{idInvestor}")]
    public async Task<IActionResult> GetAsync(long idInvestor)
    {
      var list = await service.ReadHistory(idInvestor);
      return Ok(new ResultViewModel()
      {
        Message = "Carteira obtidos(as) com sucesso",
        Success = true,
        Data = list
      });
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAsync()
    {
      var list = await service.ReadAll();
      return Ok(new ResultViewModel()
      {
        Message = "Carteira obtidos(as) com sucesso",
        Success = true,
        Data = list
      });
    }

    [HttpGet]
    [Route("get-by-id")]

    public async Task<IActionResult> GetByIdAsync(long id)
    {
      var entity = await service.ReadById(id);
      return Ok(new ResultViewModel()
      {
        Message = "Carteira obtido(a) com sucesso",
        Success = true,
        Data = entity
      });
    }

    [HttpPost]
    [Route("post")]
    public async Task<IActionResult> PostAsync([FromBody] Wallet viewModel)
    {
      var created = await service.Create(viewModel);

      return Ok(new ResultViewModel()
      {
        Message = "Carteira criado(a) com sucesso!",
        Success = true,
        Data = created
      });
    }

    [HttpPut]
    [Route("put")]
    public async Task<IActionResult> PutAsync([FromBody] Wallet viewModel)
    {
      var updated = await service.Update(viewModel);

      return Ok(new ResultViewModel()
      {
        Message = "Carteira atualizado(a) com sucesso!",
        Success = true,
        Data = updated
      });
    }



    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
      var entity = await service.ReadById(id);
      await service.Delete(entity);

      return Ok(new ResultViewModel()
      {
        Message = "Carteira deletado(a) com sucesso!",
        Success = true,
        Data = entity
      });
    }
  }
}
