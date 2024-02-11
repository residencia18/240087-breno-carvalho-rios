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

    private Atendimento GetByDbId(int id)
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
            Diagnostico = a.Diagnostico

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
            Diagnostico = a.Diagnostico

        }).ToList();

        return _atendimentos;
    }

    public AtendimentoViewModel GetById(int id)
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

        var atendimentoDb = _context.Atendimentos.Find(id);
        if (atendimentoDb is null)
            throw new AtendimentoNotFoundException();

        var medicoVM = _medicoService.GetById(atendimentoDb.Medico.MedicoId);
        var pacienteVM = _pacienteService.GetById(atendimentoDb.Paciente.PacienteId);

        if (medicoVM is null || pacienteVM is null)
            return null;

        return new AtendimentoViewModel
        {
            AtendimentoId = atendimentoDb.AtendimentoId,
            DataHoraInicio = atendimentoDb.DataHoraInicio,
            DataHoraFim = atendimentoDb.DataHoraFim,
            SuspeitaInicial = atendimentoDb.SuspeitaInicial,
            Diagnostico = atendimentoDb.Diagnostico
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
            Medico = new MedicoViewModel
            {
                MedicoId = a.Medico.MedicoId,
                Nome = a.Medico.Nome,
                Cpf = a.Medico.Cpf,
                Crm = a.Medico.Crm
            }

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
            Paciente = new PacienteViewModel
            {
                PacienteId = a.Paciente.PacienteId,
                Nome = a.Paciente.Nome,
                Cpf = a.Paciente.Cpf,
                DataNascimento = a.Paciente.DataNascimento
            }

        }).ToList();

        return _atendimento;
    }

    public void Update(int id, NewAtendimentoInputModel atendimento)
    {
        var _atendimento = GetByDbId(id);

        _atendimento.SuspeitaInicial = atendimento.SuspeitaInicial;
        _atendimento.Diagnostico = atendimento.Diagnostico;

        _context.Atendimentos.Update(_atendimento);

        _context.SaveChanges();
    }
}
