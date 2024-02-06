using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.WebAPI.InputModels;

namespace OrdemServico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ClienteController : ControllerBase
{
    [HttpGet("clientes")]
    public IActionResult Get(){
      return NoContent();
    }
    [HttpGet("cliente/{id}")]
    public IActionResult GetById(int id){
        return NoContent();
    }
    [HttpPost("cliente")]
    public IActionResult Post([FromBody] NewClienteInputModel cliente){
      return NoContent();
    }
    [HttpPut("cliente/{id}")]
    public IActionResult Put(int id, [FromBody] NewClienteInputModel cliente){
      return NoContent();
    }
    [HttpDelete("cliente/{id}")]
    public IActionResult Delete(int id){
      return NoContent();
    }
}
