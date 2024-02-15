using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using System;

namespace ResTIConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost("eventos")]
        public IActionResult Create([FromBody] NewEventoInputModel evento)
        {
            var eventoId = _eventoService.Create(evento);
            var createdEvent = _eventoService.GetById(eventoId);
            return CreatedAtAction(nameof(GetById), new { id = eventoId }, createdEvent);
        }

        [HttpGet("eventos/{id}")]
        public IActionResult GetById(int id)
        {
            var evento = _eventoService.GetById(id);
            if (evento == null)
                return NotFound();
            return Ok(evento);
        }

        [HttpPut("eventos/{id}")]
        public IActionResult Update(int id, [FromBody] NewEventoInputModel evento)
        {
            if (_eventoService.GetById(id) == null)
                return NotFound();
            _eventoService.Update(id, evento);
            return NoContent();
        }

        [HttpDelete("eventos/{id}")]
        public IActionResult Delete(int id)
        {
            if (_eventoService.GetById(id) == null)
                return NotFound();
            _eventoService.Delete(id);
            return NoContent();
        }
    }
}
