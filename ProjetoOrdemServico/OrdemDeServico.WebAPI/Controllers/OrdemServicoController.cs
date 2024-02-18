using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.WebAPI.Controllers.OrdemDeServico;

[ApiController]
[Route("/api/v0.1/")]
public class OrdemServicoController : ControllerBase
{
    private readonly IOrdemServicoService _ordemServicoService;
    public List<OrdemServicoViewModel> OrdensServico => _ordemServicoService.GetAll().ToList();
    public OrdemServicoController(IOrdemServicoService ordemServicoService)
    {
        _ordemServicoService = ordemServicoService;
    }

    [HttpGet("ordens-de-servico")]
    public IActionResult Get()
    {
        return Ok(OrdensServico);
    }

    [HttpGet("ordem-de-servico/{id}")]
    public IActionResult GetById(int id)
    {
        var _ordemServico = _ordemServicoService.GetById(id);
        return Ok(_ordemServico);
    }

    [HttpPost("ordem-de-servico")]
    public IActionResult Post([FromBody] NewOrdemServicoInputModel ordemServico)
    {
        var _ordemServicoId = _ordemServicoService.Create(ordemServico);
        return CreatedAtAction(nameof(GetById), new { id = _ordemServicoId }, ordemServico);
    }

    [HttpPut("ordem-de-servico/{id}")]
    public IActionResult Put(int id, [FromBody] UpdateOrdemDeServicoInputModel ordemServico)
    {
        _ordemServicoService.UpdateOrdemServico(id, ordemServico);
        return Ok();
    }

    [HttpDelete("ordem-de-servico/{id}")]
    public IActionResult Delete(int id)
    {
        _ordemServicoService.Delete(id);
        return NoContent();
    }

    [HttpDelete("ordem-de-servico/{ordemServicoId}/servico")]
    public IActionResult DeleteServico(int ordemServicoId, [FromBody] int servicoId)
    {
        _ordemServicoService.RemoveServico(ordemServicoId, servicoId);
        return NoContent();
    }

    [HttpPut("ordem-de-servico/{ordemServicoId}/servico")]
    public IActionResult AddServico(int ordemServicoId, [FromBody] AddServicoIntoOrdemServicoInputModel servico)
    {
        _ordemServicoService.AdicionaServico(ordemServicoId, servico);
        return Ok("Serviço Adicionado");
    }
}
