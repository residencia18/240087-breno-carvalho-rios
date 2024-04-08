using Cepedi.BancoCentral.Shareable.Responses;
using MediatR;

namespace Cepedi.BancoCentral.Shareable.Requests;
public class ObterUsuarioRequest : IRequest<ObterUsuarioResponse>
{
    public int IdUsuario { get; set; }
}
