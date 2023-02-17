using AutoMapper;
using ERP.Api.ViewModels.Exemplos;
using ERP.Business.Interfaces.Exemplos;
using ERP.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/exemplo")]
    public class ExemploController : ControllerBase
    {
        private readonly IExemploService _exemploService;
        private readonly IMapper _mapper;
        public ExemploController(IExemploService exemploService, IMapper mapper)
        {
            _exemploService = exemploService;
            _mapper = mapper;
        }
       
        [HttpPost]
        public async Task<Exemplo> Add(ExemploCreateViewModel viewModel)
        {
            var exemplo = new Exemplo(viewModel.Nome, viewModel.CpfCnpj);

            await _exemploService.Add(exemplo);
            return exemplo;
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Exemplo>> GetAll()
        {
            var users = await _exemploService.GetAll();

            return users;
        }

        [HttpGet("{id:Guid}")]
        public async Task<Exemplo> GetById(Guid id)
        {
            var exemplo = await _exemploService.GetById(id);

            return exemplo;
        }

        [HttpPut]
        public async Task<Exemplo> Update(ExemploUpdateViewModel viewModel)
        {
            var exemplo = await _exemploService.GetById(viewModel.Id);

            _mapper.Map<ExemploUpdateViewModel, Exemplo>(viewModel, exemplo);

            await _exemploService.Update(exemplo);
            return exemplo;
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            await _exemploService.Remove(id);

            return Ok();
        }
    }
}
