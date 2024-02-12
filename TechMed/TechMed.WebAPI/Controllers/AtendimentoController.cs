
using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.InterfacesServices;
using TechMed.Application.ViewModels;


namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AtendimentoController : ControllerBase
{
   private readonly IAtendimentoService _atendimentoService;
   public List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();
   public AtendimentoController(IAtendimentoService service) => _atendimentoService = service;
   [HttpGet("atendimentos")]
   public IActionResult Get()
   {
      return Ok(Atendimentos);

   }

   [HttpPost("atendimento")]
   public IActionResult Post([FromBody] NewAtendimentoInputModel atendimento)
   {
      _atendimentoService.Create(atendimento);
      return CreatedAtAction(nameof(Get), atendimento);
 
   }

   [HttpGet("atendimento/{id}")]
   public IActionResult GetAtendimentoById(int id){
      var atendimentos = _atendimentoService.GetById(id);

      
      if (atendimentos is null)
         return NoContent();
      return Ok(atendimentos);
   }
   [HttpGet("medico/{id}/atendimentos")]
   public IActionResult GetAtendimentosByMedico(int medicoId){
      var atendimentos = _atendimentoService.GetByMedicoId(medicoId);

      
      if (atendimentos is null)
         return NoContent();
      return Ok(atendimentos);
   }

   
   [HttpGet("paciente/{id}/atendimentos")]
   public IActionResult GetAtendimentosByPaciente(int pacienteId){
      var atendimentos = _atendimentoService.GetByPacienteId(pacienteId);

      
      if (atendimentos is null)
         return NoContent();
      return Ok(atendimentos);
   }
   [HttpGet("atendimentos/periodo")]
   public IActionResult Get(DateTime inicio, DateTime fim){
      var atendimentos = _atendimentoService.GetByDateInterval(inicio, fim);

      
      if (atendimentos is null)
         return NoContent();
      return Ok(atendimentos);
   }


}
