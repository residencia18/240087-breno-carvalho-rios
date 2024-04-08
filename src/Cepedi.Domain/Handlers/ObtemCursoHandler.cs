using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;

public class ObtemCursoHandler : IRequestHandler<ObtemCursoRequest, ObtemCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public ObtemCursoHandler(
        ICursoRepository cursoRepository,
        IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<ObtemCursoResponse> Handle(ObtemCursoRequest request, CancellationToken cancellationToken)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(request);

        var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);

        var duracao = $"O curso tem duração de {curso.DataInicio} até {curso.DataFim}";

        return new ObtemCursoResponse(curso.Nome, duracao, professor.Nome);
    }
}
