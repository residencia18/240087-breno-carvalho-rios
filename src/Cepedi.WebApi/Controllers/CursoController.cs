using Cepedi.Domain;
using Cepedi.Domain.Services;
using Cepedi.Shareable;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IMediator _mediator;

    public CursoController(
        ILogger<CursoController> logger,
        IMediator mediator
    )
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        var request = new ObtemCursoRequest(){
            IdCurso = idCurso
        };
        return await _mediator.Send(request);
    }

    [HttpGet]
    public async Task<ActionResult<ObtemTodosCursosResponse>> ConsultarTodosCursosAsync()
    {
        return Ok();
        // return Ok(await _obtemTodosCursosHandler.ObterTodosCursosAsync());
    }

    [HttpPost]

    [ProducesResponseType(typeof(CadastraCursoResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<CadastraCursoResponse>> CadastrarCursoAsync([FromBody] CadastraCursoRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpPut("{cursoId}")]
    public async Task<ActionResult<EditaCursoResponse>> EditarCursoAsync([FromRoute] int cursoId, [FromBody] EditaCursoRequest curso)
    {
        return Ok();
        // return Ok(await _editaCursoHandler.EditaCursoAsync(cursoId, curso));
    }
    [HttpDelete("{cursoId}")]
    public async Task<ActionResult<ObtemCursoResponse>> DeletarCursoAsync([FromRoute] int cursoId)
    {
        return Ok();
        // return Ok(await _deletaCursoHandler.DeletaCursoAsync(cursoId));
    }
}
