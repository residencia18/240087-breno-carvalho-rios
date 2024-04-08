using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.BancoCentral.Shareable.Requests;
using Cepedi.BancoCentral.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers;
public class AtualizarUsuarioRequestHandler : IRequestHandler<AtualizarUsuarioRequest, AtualizarUsuarioResponse>
{
    private readonly ILogger<AtualizarUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public AtualizarUsuarioRequestHandler(IUsuarioRepository usuarioRepository, ILogger<AtualizarUsuarioRequestHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<AtualizarUsuarioResponse> Handle(AtualizarUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(request.IdUsuario);

            usuario.Nome = request.Nome;
            usuario.DataNascimento = request.DataNascimento;
            usuario.Cpf = request.Cpf;
            usuario.Celular = request.Celular;
            usuario.CelularValidado = request.CelularValidado;
            usuario.Email = request.Email;

            await _usuarioRepository.AtualizarUsuarioAsync(usuario);

            return new AtualizarUsuarioResponse(usuario.Id, usuario.Nome);
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            throw;
        }
    }
}
