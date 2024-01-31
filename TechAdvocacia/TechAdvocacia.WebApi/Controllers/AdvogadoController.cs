using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Application.InputModels;

namespace TechAdvocacia.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AdvogadoController : ControllerBase
{
   private readonly IAdvogadoService _advogadoService;
   public List<AdvogadoViewModel> Advogados => _advogadoService.GetAll();
   public AdvogadoController(IAdvogadoService service)
   {
      _advogadoService = service;
   }

   [HttpGet("advogados")]
   public IActionResult Get()
   {
      return Ok(Advogados);
   }

   [HttpGet("advogado/{id}")]
   public IActionResult GetById(int id)
   {
      try
      {
         var advogado = _advogadoService.GetById(id);
         return Ok(advogado);
      }
      catch (Exception ex)
      {
         return BadRequest(ex.Message);
      }
   }

   [HttpPost("advogado")]
   public IActionResult Post([FromBody] NewAdvogadoInputModel advogado)
   {
      try
      {
         _advogadoService.Create(advogado);
         return CreatedAtAction(nameof(Get), advogado);
      }
      catch (Exception ex)
      {
         return BadRequest(ex.Message);
      }
   }

   [HttpPut("advogado/{id}")]
   public IActionResult Put(int id, [FromBody] NewAdvogadoInputModel advogado)
   {
      try
      {
         _advogadoService.Update(id, advogado);
         return Ok(_advogadoService.GetById(id));
      }
      catch (Exception ex)
      {
         return BadRequest(ex.Message);
      }
   }

   [HttpDelete("advogado/{id}")]
   public IActionResult Delete(int id)
   {
      try
      {
         _advogadoService.Delete(id);
         return NoContent();
      }
      catch (Exception ex)
      {
         return BadRequest(ex.Message);
      }
   }
}
