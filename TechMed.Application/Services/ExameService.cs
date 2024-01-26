using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;
public class ExameService : BaseService, IExameService
{
    private readonly IAtendimentoService _atendimentoService;
    public ExameService(ITechMedContext context, IAtendimentoService atendimentoService) : base(context) {
        _atendimentoService = atendimentoService;
    }

    public int Create(NewExameInputModel exame)
    {
        var atendimento = _context.AtendimentosCollection.GetById(exame.AtendimentoId);
        if(atendimento is null) {
            throw new AtendimentoNotFoundException();
        }

        return _context.ExamesCollection.Create(new Exame
        {
            Nome = exame.Nome,
            DataHora = exame.DataHora,
            Atendimento = atendimento,
        });
    }

    public void Delete(int id)
    {
        _context.ExamesCollection.Delete(id);
    }

    public List<ExameViewModel> GetAll()
    {
        return _context.ExamesCollection.GetAll().Select(exame => new ExameViewModel
        {
            Nome = exame.Nome,
            DataHora = exame.DataHora,
            Atendimento = _atendimentoService.GetById(exame.Atendimento.AtendimentoId)
        }).ToList();
    }

    public ExameViewModel? GetById(int id)
    {
        var exame = _context.ExamesCollection.GetById(id);
        if (exame is null)
        {
            return null;
        }
        return new ExameViewModel
        {
            Nome = exame.Nome,
            DataHora = exame.DataHora,
            Atendimento = _atendimentoService.GetById(exame.Atendimento.AtendimentoId)
        };
    }

    public void Update(int id, NewExameInputModel exame)
    {
        throw new NotImplementedException();
    }
}
