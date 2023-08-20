
using AutoMapper;
using Domain.Entities;
using Service.Interfaces;
using Application.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
  [ApiController]
  [Route("enterprise")]
  public class EnterpriseController : ControllerBase
  {
    private readonly IMapper mapper;
    private readonly IEnterpriseService service;

    public EnterpriseController(IMapper mapper, IEnterpriseService service)
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
        Message = "Empreendimento obtidos(as) com sucesso",
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
        Message = "Empreendimento obtido(a) com sucesso",
        Success = true,
        Data = entity
      });
    }

    [HttpPost]
    [Route("post")]
    public async Task<IActionResult> PostAsync([FromBody] Enterprise viewModel)
    {
      var created = await service.Create(viewModel);

      return Ok(new ResultViewModel()
      {
        Message = "Empreendimento criado(a) com sucesso!",
        Success = true,
        Data = created
      });
    }

    [HttpPut]
    [Route("put")]
    public async Task<IActionResult> PutAsync([FromBody] Enterprise viewModel)
    {
      var updated = await service.Update(viewModel);

      return Ok(new ResultViewModel()
      {
        Message = "Empreendimento atualizado(a) com sucesso!",
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
        Message = "Empreendimento deletado(a) com sucesso!",
        Success = true,
        Data = entity
      });
    }
  }
}
