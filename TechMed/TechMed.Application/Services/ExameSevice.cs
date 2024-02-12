using TechMed.Application.InputModels;
using TechMed.Application.Services;
using TechMed.Application.Services.InterfacesServices;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application;

public class ExameService : BaseService, IExameService
{
    private readonly TechMedDbContext _atendimentoService;
    public ExameService(TechMedDbContext context, IAtendimentoService atendimentoService) : base(context)
    {
        _atendimentoService = (TechMedDbContext)atendimentoService;
    }

     private Exame GetByDbId(int id)
    {
        var _exame = _context.Exames.Find(id);

        if (_exame is null)
            throw new ExameNotFoundException();
        
        return _exame;
    }

    public int Create(NewExameInputModel exame)
    {
         var _exame = new Exame
        {
           Nome = exame.Nome,
           Valor = exame.Valor,
           Local = exame.Local,
           DataHora = exame.DataHora,
           ResultadoDescricao = exame.ResultadoDescricao,
           AtendimentoId = exame.AtendimentoId
        };
        _context.Exames.Add(_exame);

        _context.SaveChanges();

        return _exame.ExameId;
    }

    public void Delete(int id)
    {
        _context.Exames.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<ExameViewModel> GetAll()
    {
        var _exame = _context.Exames.Select(m => new ExameViewModel
        {
            ExameId = m.ExameId,
            Nome = m.Nome,
            Valor = m.Valor,
            Local = m.Local,
            DataHora = m.DataHora,
            ResultadoDescricao = m.ResultadoDescricao
        }).ToList();

        return _exame;
    }

    public void Update(int id, NewExameInputModel exame)
    {
        var _exame = GetByDbId(id);

        _exame.Nome = exame.Nome;
        _exame.Valor = exame.Valor;
        _exame.Local = exame.Local;
        _exame.DataHora = exame.DataHora;
        _exame.ResultadoDescricao = exame.ResultadoDescricao;

        _context.Exames.Update(_exame);

        _context.SaveChanges();
    }

    public int Create(int atendimentoId, NewExameInputModel exame)
    {
        throw new NotImplementedException();
    }
}
