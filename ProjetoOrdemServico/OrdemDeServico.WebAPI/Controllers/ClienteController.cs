using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.WebAPI.Controllers;

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
        var _cliente = _clienteService.GetById(id);

        if (_cliente is null)
        {
            return NotFound();
        }

        return Ok(_cliente);
    }

    [HttpGet("cliente/telefone/{telefone}")]
    public IActionResult GetByTelefone(string telefone)
    {
        var cliente = _clienteService.GetByTelefone(telefone);
        return Ok(cliente);
    }
    [HttpPost("cliente")]
    public IActionResult Post([FromBody] NewClienteInputModel cliente)
    {
        var _clienteId = _clienteService.Create(cliente);

        return CreatedAtAction(nameof(Get), new { id = _clienteId }, cliente);
    }
    [HttpPut("cliente/{id}")]
    public IActionResult Put(int id, [FromBody] NewClienteInputModel cliente)
    {
        _clienteService.Update(id, cliente);

        return Ok();
    }
    [HttpDelete("cliente/{id}")]
    public IActionResult Delete(int id)
    {
        _clienteService.Delete(id);
        return NoContent();
    }
}
