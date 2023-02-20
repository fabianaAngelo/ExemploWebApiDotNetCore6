using AutoMapper;
using ERP.Api.ViewModels.Exemplos;
using ERP.Business.Interfaces;
using ERP.Business.Interfaces.Exemplos;
using ERP.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/exemplo")]
    public class ExemploController : MainController<ExemploController>
    {
        private readonly IExemploService _exemploService;
        private readonly IMapper _mapper;
        public ExemploController(IExemploService exemploService, 
            IMapper mapper,
            IErrorNotifier erroNotifier) : base(erroNotifier)
        {
            _exemploService = exemploService;
            _mapper = mapper;
        }
       
        [HttpPost]
        public async Task<ActionResult<ExemploCreateViewModel>> Add(ExemploCreateViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var exemplo = new Exemplo(viewModel.Nome, viewModel.CpfCnpj);

            await _exemploService.Add(exemplo);
            return CustomResponse(viewModel);
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Exemplo>> GetAll()
        {
            var exemplos = await _exemploService.GetAll();

            return exemplos;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Exemplo>> GetById(Guid id)
        {
            var exemplo = await _exemploService.GetById(id);
            if (exemplo == null) return NotFound();

            return exemplo;
        }

        [HttpPut]
        public async Task<ActionResult<ExemploUpdateViewModel>> Update(ExemploUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var exemplo = await _exemploService.GetById(viewModel.Id);
            if (exemplo == null) return NotFound();

            await _exemploService.Update(_mapper.Map<Exemplo>(viewModel));
            return CustomResponse(viewModel);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ExemploViewModel>> Remove(Guid id)
        {
            var exemplo = await _exemploService.GetById(id);
            if (exemplo == null) return NotFound();

            await _exemploService.Remove(id);

            return CustomResponse();
        }
    }
}
