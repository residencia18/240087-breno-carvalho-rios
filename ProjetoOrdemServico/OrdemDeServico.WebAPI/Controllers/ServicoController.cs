using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoService;

        public List<ServicoViewModel> Servicos => _servicoService.GetAll().ToList();

        public ServicoController(IServicoService servicoService) => _servicoService = servicoService;


        [HttpGet("servicos")]
        public IActionResult Get()
        {
            var servicos = _servicoService.GetAll();
            return Ok(servicos);
        }

        [HttpGet("servico/{id}")]
        public IActionResult GetById(int id)
        {
            var servico = _servicoService.GetById(id);
            if (servico == null)
            {
                return NotFound();
            }
            return Ok(servico);
        }

        [HttpGet("servico-nome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var servico = _servicoService.GetByNome(nome);
            return Ok(servico);
        }

        [HttpPost("servico")]
        public IActionResult Post([FromBody] NewServicoInputModel servicoInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var servicoId = _servicoService.Create(servicoInputModel);
            return CreatedAtAction(nameof(GetById), new { id = servicoId }, servicoInputModel);
        }

        [HttpPut("servico/{id}")]
        public IActionResult Put(int id, [FromBody] NewServicoInputModel servicoInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _servicoService.Update(id, servicoInputModel);
            return Ok();
        }

        [HttpDelete("servico/{id}")]
        public IActionResult Delete(int id)
        {
            _servicoService.Delete(id);
            return NoContent();
        }
    }
}
