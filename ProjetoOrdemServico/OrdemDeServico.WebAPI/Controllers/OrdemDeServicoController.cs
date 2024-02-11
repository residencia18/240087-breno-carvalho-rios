using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application.InputModels;

namespace OrdemDeServico.WebAPI.Controllers.OrdemDeServico;

[ApiController]
[Route("/api/v0.1/")]
public class OrdemDeServicoController : ControllerBase
{
    [HttpGet("ordens-de-servico")]
    public IActionResult Get()
    {
        return NoContent();
    }

    [HttpGet("ordem-de-servico/{id}")]
    public IActionResult GetById(int id)
    {
        return NoContent();
    }

    [HttpPost("ordem-de-servico")]
    public IActionResult Post([FromBody] NewOrdemDeServicoInputModel ordemDeServico)
    {
        return NoContent();
    }

    [HttpPut("ordem-de-servico/{id}")]
    public IActionResult Put(int id, [FromBody] NewOrdemDeServicoInputModel ordemDeServico)
    {
        return NoContent();
    }

    [HttpDelete("ordem-de-servico/{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
