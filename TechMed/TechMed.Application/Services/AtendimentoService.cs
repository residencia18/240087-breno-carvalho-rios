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
    private readonly IExameService _exameService;

    public AtendimentoService(TechMedDbContext context, IMedicoService medicoService, IPacienteService pacienteService, IExameService exameService) : base(context)
    {
        _medicoService = medicoService;
        _pacienteService = pacienteService;
        _exameService = exameService;
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
        var _paciente = _pacienteService.GetByDbId(atendimento.PacienteId);
        var _medico = _medicoService.GetByDbId(atendimento.MedicoId);

        var _atendimento = new Atendimento
        {
            DataHoraInicio = atendimento.DataHoraInicio,
            DataHoraFim = atendimento.DataHoraFim,
            SuspeitaInicial = atendimento.SuspeitaInicial,
            Diagnostico = atendimento.Diagnostico,
            MedicoId = _medico.MedicoId,
            PacienteId = _paciente.PacienteId
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
            Paciente = _pacienteService.GetById(a.PacienteId)!,
            Exames = _exameService.GetByAtendimentoId(a.AtendimentoId)
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
            Paciente = _pacienteService.GetById(a.PacienteId)!,
            Exames = _exameService.GetByAtendimentoId(a.AtendimentoId)
        }).ToList();

        return _atendimentos;
    }

    public AtendimentoViewModel? GetById(int id)
    {
        var atendimentoDb = GetByDbId(id);

        return new AtendimentoViewModel
        {
            AtendimentoId = atendimentoDb.AtendimentoId,
            DataHoraInicio = atendimentoDb.DataHoraInicio,
            DataHoraFim = atendimentoDb.DataHoraFim,
            SuspeitaInicial = atendimentoDb.SuspeitaInicial,
            Diagnostico = atendimentoDb.Diagnostico,
            Medico = _medicoService.GetById(atendimentoDb.MedicoId)!,
            Paciente = _pacienteService.GetById(atendimentoDb.PacienteId)!,
            Exames = _exameService.GetByAtendimentoId(atendimentoDb.AtendimentoId)
        };
    }

    public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
    {
        var _medicoDb = _medicoService.GetByDbId(medicoId);

        var _atendimentos = _context.Atendimentos.Where(a => a.MedicoId == medicoId).Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraFim = a.DataHoraFim,
            DataHoraInicio = a.DataHoraInicio,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = _medicoService.GetById(a.MedicoId)!,
            Paciente = _pacienteService.GetById(a.PacienteId)!,
            Exames = _exameService.GetByAtendimentoId(a.AtendimentoId)
        }).ToList();

        return _atendimentos;
    }

    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
    {
        var _pacienteDb = _pacienteService.GetByDbId(pacienteId);

        var _atendimentos = _context.Atendimentos.Where(a => a.PacienteId == pacienteId).Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraFim = a.DataHoraFim,
            DataHoraInicio = a.DataHoraInicio,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            Medico = _medicoService.GetById(a.MedicoId)!,
            Paciente = _pacienteService.GetById(a.PacienteId)!,
            Exames = _exameService.GetByAtendimentoId(a.AtendimentoId)
        }).ToList();

        return _atendimentos;
    }

    public void Update(int id, NewAtendimentoInputModel atendimento)
    {
        var _atendimento = GetByDbId(id);
        var _paciente = _pacienteService.GetByDbId(atendimento.PacienteId);
        var _medico = _medicoService.GetByDbId(atendimento.MedicoId);

        _atendimento.SuspeitaInicial = atendimento.SuspeitaInicial;
        _atendimento.Diagnostico = atendimento.Diagnostico;
        _atendimento.MedicoId = _medico.MedicoId;
        _atendimento.PacienteId = _paciente.PacienteId;

        _context.Atendimentos.Update(_atendimento);

        _context.SaveChanges();
    }
}
