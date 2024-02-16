using TechMed.Application.InputModels;
using TechMed.Application.Services;
using TechMed.Application.Services.InterfacesServices;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application;

public class ExameService : BaseService, IExameService
{
    public ExameService(TechMedDbContext context) : base(context)
    {
    }

    public Exame GetByDbId(int id)
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

    public ExameViewModel? GetById(int id)
    {
        var _exame = GetByDbId(id);

        return new ExameViewModel
        {
            Nome = _exame.Nome,
            DataHora = _exame.DataHora,
            Local = _exame.Local,
            ResultadoDescricao = _exame.ResultadoDescricao,
            Valor = _exame.Valor
        };
    }

    public List<ExameViewModel> GetByAtendimentoId(int id)
    {
        var _exames = _context.Exames.Where(m => m.AtendimentoId == id).Select(exame => new ExameViewModel
        {
            Nome = exame.Nome,
            DataHora = exame.DataHora,
            Local = exame.Local,
            ResultadoDescricao = exame.ResultadoDescricao,
            Valor = exame.Valor
        }).ToList();

        return _exames;
    }
}
