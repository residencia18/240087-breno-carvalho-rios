
using Microsoft.EntityFrameworkCore;
using TechMed.Application.InputModels;
using TechMed.Application.Services.InterfacesServices;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;

public class MedicoService : IMedicoService
{
    private readonly TechMedDbContext _context;
    public MedicoService(TechMedDbContext context)
    {
        _context = context;
    }

    public Medico GetByDbId(int id)
    {
        var _medico = _context.Medicos.Find(id);

        if (_medico is null)
            throw new MedicoNotFoundException();

        return _medico;
    }

    private Medico GetByDbCrm(string crm)
    {
        var _medico = _context.Medicos.Find(crm);

        if (_medico is null)
            throw new MedicoNotFoundException();

        return _medico;
    }

    public int Create(NewMedicoInputModel medico)
    {
        var _medico = new Medico
        {
            Nome = medico.Nome,
            Crm = medico.Crm,
            Cpf = medico.Cpf
        };
        _context.Medicos.Add(_medico);

        _context.SaveChanges();

        return _medico.MedicoId;
    }

    public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
    {
        var medico = GetByDbId(medicoId);
        if (medico is null)
            throw new MedicoNotFoundException();

        var paciente = _context.Pacientes.Find(atendimento.PacienteId);
        //var paciente = _context.Pacientes.GetById(atendimento.PacienteId);
        if (paciente is null)
            throw new PacienteNotFoundException();

        return _context.Atendimentos.Add(new Atendimento
        {
            DataHoraInicio = atendimento.DataHoraInicio,
            DataHoraFim = atendimento.DataHoraFim,
            SuspeitaInicial = atendimento.SuspeitaInicial,
            Diagnostico = atendimento.Diagnostico,
            Medico = medico,
            Paciente = paciente,
            PacienteId = atendimento.PacienteId,
            MedicoId = medicoId

        }).Entity.AtendimentoId;
    }

    public void Delete(int id)
    {
        _context.Medicos.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<MedicoViewModel> GetAll()
    {
        var _medico = _context.Medicos.Select(m => new MedicoViewModel
        {
            MedicoId = m.MedicoId,
            Nome = m.Nome,
            Crm = m.Crm,
            Cpf = m.Cpf
        }).ToList();

        return _medico;
    }

    public MedicoViewModel GetByCrm(string crm)
    {
        var _medico = GetByDbCrm(crm);

        var MedicoViewModel = new MedicoViewModel
        {
            MedicoId = _medico.MedicoId,
            Nome = _medico.Nome,
            Crm = _medico.Crm,
            Cpf = _medico.Cpf

        };
        return MedicoViewModel;
    }

    public MedicoViewModel GetById(int id)
    {
        var _medico = GetByDbId(id);

        var MedicoViewModel = new MedicoViewModel
        {
            MedicoId = _medico.MedicoId,
            Nome = _medico.Nome,
            Crm = _medico.Crm,
            Cpf = _medico.Cpf

        };
        return MedicoViewModel;
    }

    public void Update(int id, NewMedicoInputModel medico)
    {
        var _medico = GetByDbId(id);

        _medico.Nome = medico.Nome;

        _medico.Crm = medico.Crm;

        _medico.Cpf = medico.Cpf;

        _context.Medicos.Update(_medico);
        _context.SaveChanges();
    }
}
