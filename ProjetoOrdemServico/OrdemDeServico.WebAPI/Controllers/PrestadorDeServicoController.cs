using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
namespace OrdemDeServico.WebAPI.Controllers.PrestadorDeServico;

[ApiController]
[Route("/api/v0.1/")]
public class PrestadorDeServicoController : ControllerBase
{
    private readonly IPrestadorDeServicoService _prestadorDeServicoService;
    public List<PrestadorDeServicoViewModel> PrestadoresDeServico => _prestadorDeServicoService.GetAll().ToList();
    public PrestadorDeServicoController(IPrestadorDeServicoService service) => _prestadorDeServicoService = service;
    [HttpGet("prestadores-de-servico")]
    public IActionResult Get()
    {
        return Ok(PrestadoresDeServico);
    }

    [HttpGet("prestador-de-servico/{id}")]
    public IActionResult GetById(int id)
    {
        var _prestadorDeServico = _prestadorDeServicoService.GetById(id);

        if (_prestadorDeServico is null)
        {
            return NotFound();
        }

        return Ok(_prestadorDeServico);
    }

    [HttpGet("prestador-de-servico/{especialidade}")]
    public IActionResult GetByEspecialidade(string especialidade)
    {
        var _prestadorDeServico = _prestadorDeServicoService.GetByEspecialidade(especialidade);
        return Ok(_prestadorDeServico);
    }

    [HttpPost("prestador-de-servico")]
    public IActionResult Post([FromBody] NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        var _prestadorDeServicoId = _prestadorDeServicoService.Create(prestadorDeServico);

        return CreatedAtAction(nameof(Get), new { id = _prestadorDeServicoId }, prestadorDeServico);
    }

    [HttpPut("prestador-de-servico/{id}")]
    public IActionResult Put(int id, [FromBody] NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        _prestadorDeServicoService.Update(id, prestadorDeServico);

        return Ok();
    }

    [HttpDelete("prestador-de-servico/{id}")]
    public IActionResult Delete(int id)
    {
        _prestadorDeServicoService.Delete(id);
        return NoContent();
    }
}
