
using AutoMapper;
using Domain.Entities;
using Service.Interfaces;
using Application.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
  [ApiController]
  [Route("contribution")]
  public class ContributionController : ControllerBase
  {
    private readonly IMapper mapper;
    private readonly IContributionService service;

    public ContributionController(IMapper mapper, IContributionService service)
    {
      this.mapper = mapper;
      this.service = service;
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAsync()
    {
      var list = await service.ReadAll();
      return Ok(new ResultViewModel()
      {
        Message = "Contribuição obtidos(as) com sucesso",
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
        Message = "Contribuição obtido(a) com sucesso",
        Success = true,
        Data = entity
      });
    }

    [HttpPost]
    [Route("post")]
    public async Task<IActionResult> PostAsync([FromBody] Contribution viewModel)
    {
      var created = await service.Create(viewModel);

      return Ok(new ResultViewModel()
      {
        Message = "Contribuição criado(a) com sucesso!",
        Success = true,
        Data = created
      });
    }

    [HttpPut]
    [Route("put")]
    public async Task<IActionResult> PutAsync([FromBody] Contribution viewModel)
    {
      var updated = await service.Update(viewModel);

      return Ok(new ResultViewModel()
      {
        Message = "Contribuição atualizado(a) com sucesso!",
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
        Message = "Contribuição deletado(a) com sucesso!",
        Success = true,
        Data = entity
      });
    }
  }
}
