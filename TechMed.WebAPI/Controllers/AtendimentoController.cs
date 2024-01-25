using Microsoft.AspNetCore.Mvc;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AtendimentoController : ControllerBase
{
   private readonly IAtendimentoService _atendimentoService;
   public List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll().ToList();
   public AtendimentoController(IAtendimentoService service) => _atendimentoService = service;
   [HttpGet("atendimentos")]
   public IActionResult GetAll()
   {
      return Ok(Atendimentos);
   }
}
