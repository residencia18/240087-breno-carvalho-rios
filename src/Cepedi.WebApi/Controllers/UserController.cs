using Cepedi.BancoCentral.Domain;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.BancoCentral.Shareable.Requests;
using Cepedi.BancoCentral.Shareable.Responses;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(
        ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{idUsuario}")]
    [ProducesResponseType(typeof(CriarUsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ObterUsuarioResponse>> ObterUsuarioAsync([FromRoute] int idUsuario)
    {
        var request = new ObterUsuarioRequest()
        {
            IdUsuario = idUsuario
        };

        return await _mediator.Send(request);
    }

    //[HttpGet()]
    //public async Task<ActionResult<IEnumerable<CriarUsuarioResponse>>> ConsultarCursosAsync()
    //{
    //    return Ok(await _obtemCursoHandler.ObterCursosAsync());
    //}

    [HttpPost]
    [ProducesResponseType(typeof(CriarUsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarUsuarioResponse>> CriarUsuarioAsync(
        [FromBody] CriarUsuarioRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(CriarUsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AtualizarUsuarioResponse>> AlterarUsuarioAsync([FromBody] AtualizarUsuarioRequest request)
    {
       return await _mediator.Send(request);
    }
}
