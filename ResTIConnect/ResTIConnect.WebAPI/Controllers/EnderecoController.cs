using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;
    public List<EnderecoViewModel> Enderecos => _enderecoService.GetAll().ToList();
    public EnderecoController(IEnderecoService endereco) => _enderecoService = endereco;

    [HttpGet("enderecos")]
    public IActionResult Get()
    {
        return Ok(Enderecos);
    }

    [HttpGet("endereco/{id}")]
    public IActionResult GetById(int id)
    {
        var endereco = _enderecoService.GetById(id);
        if (endereco is null)
            return NoContent();
        return Ok(endereco);
    }

    [HttpPost("endereco")]
    public IActionResult Post([FromBody] NewEnderecoInputModel endereco)
    {
        _enderecoService.Create(endereco);
        return CreatedAtAction(nameof(Get), endereco);

    }

    [HttpPut("endereco/{id}")]
    public IActionResult Put(int id, [FromBody] NewEnderecoInputModel endereco)
    {
        if (_enderecoService.GetById(id) == null)
            return NoContent();
        _enderecoService.Update(id, endereco);
        return Ok(_enderecoService.GetById(id));
    }

    [HttpDelete("endereco/{id}")]
    public IActionResult Delete(int id)
    {
        if (_enderecoService.GetById(id) == null)
            return NoContent();
        _enderecoService.Delete(id);
        return Ok();
    }
}
