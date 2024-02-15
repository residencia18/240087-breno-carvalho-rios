using TechMed.Application.InputModels;
using TechMed.Application.Services.InterfacesServices;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;

public class AtendimentoService : BaseService, IAtendimentoService
{
    private readonly IMedicoService _medicoService;
    private readonly IPacienteService _pacienteService;

    public AtendimentoService(TechMedDbContext context, IMedicoService medicoService, IPacienteService pacienteService) : base(context)
    {
        _medicoService = medicoService;
        _pacienteService = pacienteService;
    }

    public Atendimento GetByDbId(int id)
    {
        var _atendimento = _context.Atendimentos.Find(id);

        if (_atendimento is null)
            throw new AtendimentoNotFoundException();

        return _atendimento;
    }

    public int Create(NewAtendimentoInputModel atendimento)
    {
        var _atendimento = new Atendimento
        {
            DataHoraInicio = atendimento.DataHoraInicio,
            DataHoraFim = atendimento.DataHoraFim,
            SuspeitaInicial = atendimento.SuspeitaInicial,
            Diagnostico = atendimento.Diagnostico,
            MedicoId = atendimento.MedicoId,
            PacienteId = atendimento.PacienteId
        };
        _context.Atendimentos.Add(_atendimento);

        _context.SaveChanges();

        return _atendimento.AtendimentoId;
    }

    public void Delete(int id)
    {
        _context.Atendimentos.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<AtendimentoViewModel> GetAll()
    {
        var _atendimentos = _context.Atendimentos.Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraFim = a.DataHoraFim,
            DataHoraInicio = a.DataHoraInicio,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = _medicoService.GetById(a.MedicoId)!,
            Paciente = _pacienteService.GetById(a.PacienteId)!
        }).ToList();

        return _atendimentos;
    }

    public ICollection<AtendimentoViewModel> GetByDateInterval(DateTimeOffset dataInicial, DateTimeOffset dataFinal)
    {
        var _atendimentos = _context.Atendimentos.Where(a => a.DataHoraFim >= dataInicial && a.DataHoraFim <= dataFinal).Select(a => new
        AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraInicio = a.DataHoraInicio,
            DataHoraFim = a.DataHoraFim,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = _medicoService.GetById(a.MedicoId)!,
            Paciente = _pacienteService.GetById(a.PacienteId)!
        }).ToList();

        return _atendimentos;
    }

    public AtendimentoViewModel? GetById(int id)
    {
        // var _atendimento = GetByDbId(id);

        // var AtendimentoViewModel = new AtendimentoViewModel
        // {
        //     AtendimentoId = _atendimento.AtendimentoId,
        //     DataHoraInicio = _atendimento.DataHoraInicio,
        //     DataHoraFim = _atendimento.DataHoraFim,
        //     SuspeitaInicial = _atendimento.SuspeitaInicial,
        //     Diagnostico = _atendimento.Diagnostico
        // };
        // return AtendimentoViewModel;

        var atendimentoDb = GetByDbId(id);

        return new AtendimentoViewModel
        {
            AtendimentoId = atendimentoDb.AtendimentoId,
            DataHoraInicio = atendimentoDb.DataHoraInicio,
            DataHoraFim = atendimentoDb.DataHoraFim,
            SuspeitaInicial = atendimentoDb.SuspeitaInicial,
            Diagnostico = atendimentoDb.Diagnostico,
            Medico = _medicoService.GetById(atendimentoDb.MedicoId)!,
            Paciente = _pacienteService.GetById(atendimentoDb.PacienteId)!
        };
    }

    public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
    {
        var _atendimento = _context.Atendimentos.Where(a => a.MedicoId == medicoId).Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraFim = a.DataHoraFim,
            DataHoraInicio = a.DataHoraInicio,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = _medicoService.GetById(a.MedicoId)!,
            Paciente = _pacienteService.GetById(a.PacienteId)!

        }).ToList();

        return _atendimento;
    }

    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
    {
        var _atendimento = _context.Atendimentos.Where(a => a.PacienteId == pacienteId).Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraFim = a.DataHoraFim,
            DataHoraInicio = a.DataHoraInicio,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = _medicoService.GetById(a.MedicoId)!,
            Paciente = _pacienteService.GetById(a.PacienteId)!
        }).ToList();

        return _atendimento;
    }

    public void Update(int id, NewAtendimentoInputModel atendimento)
    {
        var _atendimento = GetByDbId(id);

        _atendimento.SuspeitaInicial = atendimento.SuspeitaInicial;
        _atendimento.Diagnostico = atendimento.Diagnostico;
        _atendimento.MedicoId = atendimento.MedicoId;
        _atendimento.PacienteId = atendimento.PacienteId;

        _context.Atendimentos.Update(_atendimento);

        _context.SaveChanges();
    }
}
