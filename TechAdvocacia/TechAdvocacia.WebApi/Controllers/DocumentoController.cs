using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;

namespace TechAdvocacia.WebApi.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class DocumentoController : ControllerBase
{
    private readonly IDocumentoService _documentoService;
    public List<DocumentoViewModel> Documentos => _documentoService.GetAll();

    public DocumentoController(IDocumentoService documentoService)
    {
        _documentoService = documentoService;
    }

    [HttpGet("documentos")]
    public IActionResult Get()
    {
        return Ok(Documentos);
    }

    [HttpGet("documento/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var _documento = _documentoService.GetById(id);
            return Ok(_documento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("documento")]
    public IActionResult Post([FromBody] NewDocumentoInputModel documento)
    {
        try
        {
            _documentoService.Create(documento);
            return CreatedAtAction(nameof(Get), documento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("documento/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _documentoService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("documento/{id}")]
    public IActionResult Put(int id, [FromBody] NewDocumentoInputModel documento)
    {
        try
        {
            _documentoService.Update(id, documento);
            return Ok(_documentoService.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
