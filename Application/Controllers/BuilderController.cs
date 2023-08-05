using AutoMapper;
using Domain.Entities;
using Service.Interfaces;
using Application.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("builder")]
    public class BuilderController: ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBuilderService service;

        public BuilderController(IMapper mapper, IBuilderService service) 
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAsync()
        {
            var builders = await service.ReadAll();
            return Ok(new ResultViewModel()
            {
                Message = "Construtoras obtidas com sucesso",
                Success = true,
                Data = builders
            });
        }

        [HttpGet]
        [Route("get-by-id")]

        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var entity = await service.ReadById(id);
            return Ok(new ResultViewModel()
            {
                Message = "Construtora obtida com sucesso",
                Success = true,
                Data = entity
            });
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> PostAsync([FromBody] Builder viewModel)
        {
            var created = await service.Create(viewModel);

            return Ok(new ResultViewModel()
            {
                Message = "Construtora criada com sucesso!",
                Success = true,
                Data = created
            });
        }

        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> PutAsync([FromBody] Builder viewModel)
        {
            var userUpdated = await service.Update(viewModel);

            return Ok(new ResultViewModel()
            {
                Message = "Construtora atualizada com sucesso!",
                Success = true,
                Data = userUpdated
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
                Message = "Construtora deletada com sucesso!",
                Success = true
            });
        }
    }
}
