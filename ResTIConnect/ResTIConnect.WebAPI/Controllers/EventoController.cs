using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using System;

namespace ResTIConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public List<EventoViewModel> Eventos => _eventoService.GetAll();

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost("eventos")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Create([FromBody] NewEventoInputModel evento)
        {
            try
            {
                var eventoId = _eventoService.Create(evento);
                var createdEvent = _eventoService.GetById(eventoId);
                return CreatedAtAction(nameof(GetById), new { id = eventoId }, createdEvent);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("eventos/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult GetById(int id)
        {
            try
            {
                var evento = _eventoService.GetById(id);
                if (evento == null)
                    return NotFound();
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("eventos")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Get()
        {
            return Ok(Eventos);
        }

        [HttpPut("eventos/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Update(int id, [FromBody] NewEventoInputModel evento)
        {
            try
            {
                if (_eventoService.GetById(id) == null)
                    return NotFound();
                _eventoService.Update(id, evento);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("eventos/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_eventoService.GetById(id) == null)
                    return NotFound();
                _eventoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
