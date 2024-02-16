
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
   private readonly IExameService _exameService;
   public List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();
   public AtendimentoController(IAtendimentoService service, IExameService exameService)
   {
      _atendimentoService = service;
      _exameService = exameService;
   }

   [HttpPost("atendimento")]
   public IActionResult Post([FromBody] NewAtendimentoInputModel atendimento)
   {
      var atendimentoId = _atendimentoService.Create(atendimento);
      return CreatedAtAction(nameof(GetAtendimentoById), new { id = atendimentoId }, atendimento);
   }

   [HttpGet("atendimento/{id}")]
   public IActionResult GetAtendimentoById(int id)
   {
      var atendimento = _atendimentoService.GetById(id);

      if (atendimento is null)
         return NoContent();
      return Ok(atendimento);
   }

   [HttpGet("atendimentos/porPeriodo/{inicio}/{fim}")]
   public IActionResult GetByDateInterval(DateTime inicio, DateTime fim)
   {
      var atendimentos = _atendimentoService.GetByDateInterval(inicio, fim);

      if (atendimentos is null)
         return NoContent();
      return Ok(atendimentos);
   }

   [HttpGet("atendimentos")]
   public IActionResult Get()
   {
      return Ok(Atendimentos);
   }

   [HttpPut("atendimento/{id}")]
   public IActionResult Put(int id, [FromBody] NewAtendimentoInputModel atendimento)
   {
      _atendimentoService.Update(id, atendimento);
      return Ok(_atendimentoService.GetById(id));
   }

   [HttpDelete("atendimento/{id}")]
   public IActionResult Delete(int id)
   {
      _atendimentoService.Delete(id);
      return NoContent();
   }

   [HttpGet("atendimentos/{id}/exames")]
   public IActionResult GetExamesByAtendimento(int id)
   {
      var _exames = _exameService.GetByAtendimentoId(id);
      return Ok(_exames);
   }
}
