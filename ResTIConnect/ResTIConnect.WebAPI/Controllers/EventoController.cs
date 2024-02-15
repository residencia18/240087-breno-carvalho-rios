using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using System;
using System.Collections.Generic;

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

        [HttpGet("eventos/tipo/{tipo}")]
        public IActionResult GetByTipo(string tipo)
        {
            var eventos = _eventoService.GetByTipo(tipo);
            return Ok(eventos);
        }

        [HttpGet("eventos/usuario/{usuarioId}")]
        public IActionResult GetByUsuarioId(int usuarioId)
        {
            var eventos = _eventoService.GetByUsuarioId(usuarioId);
            return Ok(eventos);
        }

        [HttpGet("eventos/datahora/{dataHora}")]
        public IActionResult GetByDataHoraOcorrencia(DateTimeOffset dataHora)
        {
            var eventos = _eventoService.GetByDataHoraOcorrencia(dataHora);
            return Ok(eventos);
        }

        [HttpGet("eventos/sistema/{sistemaId}")]
        public IActionResult GetBySistemaId(int sistemaId)
        {
            var eventos = _eventoService.GetBySistemaId(sistemaId);
            return Ok(eventos);
        }

        [HttpPost("eventos")]
        public IActionResult Create([FromBody] NewEventoInputModel evento)
        {
            var eventoId = _eventoService.Create(evento);
            var createdEvent = _eventoService.GetById(eventoId);
            return CreatedAtAction(nameof(GetByTipo), new { tipo = evento.Tipo }, createdEvent);
        }

        [HttpPut("eventos/{id}")]
        public IActionResult Update(int id, [FromBody] NewEventoInputModel evento)
        {
            if (_eventoService.GetById(id) == null)
                return NotFound();
            _eventoService.Update(id, evento);
            return Ok(_eventoService.GetById(id));
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
