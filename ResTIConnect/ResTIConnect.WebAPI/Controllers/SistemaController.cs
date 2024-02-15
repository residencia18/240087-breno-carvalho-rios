using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.WebAPI.Controllers
{

    [ApiController]
    [Route("/api/v0.1/")]
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
        [HttpGet("system/user/{id}")]
        public IActionResult GetSistemasByUserId(int usuarioId)
        {
            var sistemas = _sistemaService.GetUserById(usuarioId);
            return Ok(sistemas);
        }

        [HttpGet("system/event/{type}/from/{date}")] 
        public IActionResult GetSistemasByEventoTipoByData(String tipo, DateTime dataInicio)
        {

            var sistemas = _sistemaService.GetByEventoPeriodos(tipo, dataInicio);
            return Ok(sistemas);
             
        }
         [HttpPut("evento/{eventoId}/sistema/{sistemaId}")]
               
               
        public IActionResult AdicionaSistemaAoEvento(int eventoId, int sistemaId)
        {
                //_sistemaService.AdicionaSistemaAoEvento(eventoId, sistemaId);
                return Ok("Evento adicionado ao sistema com sucesso");
           
        }
        

    }
}
