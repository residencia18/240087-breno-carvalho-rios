using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.BancoCentral.Shareable.Requests;
using Cepedi.BancoCentral.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers;
public class ObterUsuarioRequestHandler : IRequestHandler<ObterUsuarioRequest, ObterUsuarioResponse>
{
    private readonly ILogger<ObterUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterUsuarioRequestHandler(IUsuarioRepository usuarioRepository, ILogger<ObterUsuarioRequestHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }
    public async Task<ObterUsuarioResponse> Handle(ObterUsuarioRequest request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObterUsuarioAsync(request.IdUsuario);
        return new ObterUsuarioResponse(){
            Nome = usuario.Nome,
            DataNascimento = usuario.DataNascimento,
            Cpf = usuario.Cpf,
            Celular = usuario.Celular,
            CelularValidado = usuario.CelularValidado,
            Email = usuario.Email
        };
    }
}
