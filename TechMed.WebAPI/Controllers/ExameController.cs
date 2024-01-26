using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ExameController : ControllerBase
{
    private readonly IExameService _exameService;
    public List<ExameViewModel> Exames => _exameService.GetAll();
    public ExameController(IExameService exameService){
        _exameService = exameService;
    }

    [HttpGet("exames")]
    public IActionResult GetAll(){
        return Ok(Exames);
    }

    [HttpGet("exame/{id}")]
    public IActionResult Get(int id){
        var exame =_exameService.GetById(id);
        if(exame is null){
            return NoContent();
        }
        return Ok(exame);
    }

    [HttpPost("exame")]
    public IActionResult Post([FromBody] NewExameInputModel exame){
        _exameService.Create(exame);
        return Ok();
    }
}
