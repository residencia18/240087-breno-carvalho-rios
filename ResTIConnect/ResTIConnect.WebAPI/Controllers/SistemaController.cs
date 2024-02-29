using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.WebAPI.Controllers
{

    [ApiController]
    [Route("/api/v0.1/")]
    [Authorize(Roles="Admin")]
    public class SistemaController : ControllerBase
    {
        private readonly ISistemaService _sistemaService;
        public List<SistemaViewModel> Sistemas => _sistemaService.GetAll();
        public SistemaController(ISistemaService sistemaService) => _sistemaService = sistemaService;

        [HttpGet("sistemas")]
        
        public IActionResult Get()
        {
            return Ok(Sistemas);
        }
        [HttpGet("sistema/{id}")]
        
        public IActionResult GetById(int id)
        {
            var sistema = _sistemaService.GetById(id);
            return Ok(sistema);
        }

        [HttpPost("sistema")]
        
        public IActionResult Post([FromBody] NewSistemaInputModel sistema)
        {
            _sistemaService.Create(sistema);
            return CreatedAtAction(nameof(Get), sistema);
        }

        [HttpGet("sistema/usuario/{usuarioId}")]
        
        public IActionResult GetSistemasByUserId(int usuarioId)
        {
            var sistemas = _sistemaService.GetSistemasByUserId(usuarioId);
            return Ok(sistemas);
        }

        [HttpGet("sistema/evento/{tipo}/from/{dataInicio}")]
        
        public IActionResult GetSistemasByEventoTipoByData(string tipo, DateTime dataInicio)
        {

            var sistemas = _sistemaService.GetByEventoPeriodos(tipo, dataInicio);
            return Ok(sistemas);

        }

        [HttpPut("sistema/{sistemaId}/evento")]
        
        public IActionResult AdicionaEventoAoSistema(int sistemaId, [FromBody] int eventoId)
        {
            _sistemaService.AdicionaEventoAoSistema(eventoId, sistemaId);
            return Ok("Evento adicionado ao sistema com sucesso");
        }

        [HttpPut("sistema/{sistemaId}/usuario")]
        
        public IActionResult AdicionaUsuarioAoSistema(int sistemaId, [FromBody] int usuarioId)
        {
            _sistemaService.AdicionaUsuarioAoSistema(sistemaId, usuarioId);
            return Ok("Usuário adicionado ao sistema com sucesso");
        }

        [HttpPut("sistema/{id}")]
        
        public IActionResult Put(int id, [FromBody] NewSistemaInputModel sistema)
        {
            _sistemaService.Update(id, sistema);
            return Ok(sistema);
        }

        [HttpDelete("sistema/{id}")]
        
        public IActionResult Delete(int id)
        {
            _sistemaService.Delete(id);
            return NoContent();
        }
    }
}
