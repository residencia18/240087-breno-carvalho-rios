using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ClienteController : ControllerBase
{
   private readonly IClienteService _clienteService;
   public List<ClienteViewModel> Clientes => _clienteService.GetAll().ToList();
   public ClienteController(IClienteService service) => _clienteService = service;

   [HttpGet("clientes")]
   public IActionResult Get()
   {
      return Ok(Clientes);
   }

   [HttpGet("cliente/{id}")]
   public IActionResult GetById(int id)
   {
      try{
         var cliente = _clienteService.GetById(id);
         return Ok(cliente);
      }
      catch(Exception ex){
         return BadRequest(ex.Message);
      }
   }

   [HttpPost("cliente")]
   public IActionResult Post([FromBody] NewClientInputModel cliente)
   {
      _clienteService.Create(cliente);

      return CreatedAtAction(nameof(Get), cliente);
 
   }

   [HttpPut("cliente/{id}")]
   public IActionResult Put(int id, [FromBody] NewClientInputModel cliente)
   {
      if (_clienteService.GetById(id) == null)
         return NoContent();
      _clienteService.Update(id, cliente);
      return Ok(_clienteService.GetById(id));
   }

   [HttpDelete("cliente/{id}")]
   public IActionResult Delete(int id)
   {
      if (_clienteService.GetById(id) == null)
         return NoContent();
      _clienteService.Delete(id);
      return Ok();
   }
}
