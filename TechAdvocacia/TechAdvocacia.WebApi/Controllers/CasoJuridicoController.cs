using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;

namespace TechAdvocacia.WebApi.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class CasoJuridicoController : ControllerBase
{
    private readonly ICasoJuridicoService _casoJuridicoService;
    public List<CasoJuridicoViewModel> CasosJuridicos => _casoJuridicoService.GetAll();

    public CasoJuridicoController(ICasoJuridicoService casoJuridicoService)
    {
        _casoJuridicoService = casoJuridicoService;
    }

    [HttpGet("casos-juridicos")]
    public IActionResult Get()
    {
        return Ok(CasosJuridicos);
    }

    [HttpGet("caso-juridico/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var _casoJuridico = _casoJuridicoService.GetById(id);
            return Ok(_casoJuridico);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("caso-juridico")]
    public IActionResult Post([FromBody] NewCasoJuridicoInputModel casoJuridico)
    {
        try
        {
            _casoJuridicoService.Create(casoJuridico);
            return CreatedAtAction(nameof(Get), casoJuridico);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("caso-juridico/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _casoJuridicoService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("caso-juridico/{id}")]
    public IActionResult Put(int id, [FromBody] NewCasoJuridicoInputModel casoJuridico)
    {
        try
        {
            _casoJuridicoService.Update(id, casoJuridico);
            return Ok(_casoJuridicoService.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
