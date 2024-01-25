using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PacienteController : ControllerBase
{
   private readonly IPacienteService _service;
   public List<PacienteViewModel> Pacientes => _service.GetAll().ToList();
   public PacienteController(IPacienteService service) => _service = service;

   [HttpGet("pacientes")]
   public IActionResult Get()
   {
      return Ok(Pacientes);
   }

   [HttpGet("paciente/{id}")]
   public IActionResult GetById(int id)
   {
      var paciente = _service.GetById(id);
      return Ok(paciente);
   }

   [HttpPost("paciente")]
   public IActionResult Post([FromBody] NewPacienteInputModel paciente)
   {
      _service.Create(paciente);
      return CreatedAtAction(nameof(Get), paciente);
   }

   [HttpPut("paciente/{id}")]
   public IActionResult Put(int id, [FromBody] NewPacienteInputModel paciente)
   {
      if (_service.GetById(id) == null)
         return NoContent();
      _service.Update(id, paciente);
      return Ok(_service.GetById(id));
   }

   [HttpDelete("paciente/{id}")]
   public IActionResult Delete(int id)
   {
      if (_service.GetById(id) == null)
         return NoContent();
      _service.Delete(id);
      return Ok();
   }

   // [HttpGet("medico/{id}/atendimentos")]
   // public IActionResult GetAtendimentos(int id)
   // {
   //    var atendimento = Enumerable.Range(1, 5).Select(index => new Atendimento
   //      {
   //          AtendimentoId = index,
   //          DataHora = DateTime.Now,
   //          MedicoId = id,
   //          Medico = new Medico
   //          {
   //              MedicoId = id,
   //              Nome = $"Medico {id}"
   //          }
   //      })
   //      .ToArray();
   //    return Ok(atendimento);
   // }
}
