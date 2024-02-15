﻿using TechMed.Application.InputModels;
using TechMed.Application.Services.InterfacesServices;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;

public class PacienteService : BaseService, IPacienteService
{
    public PacienteService(TechMedDbContext context) : base(context) { }

    public Paciente GetByDbId(int id)
    {
        var _paciente = _context.Pacientes.Find(id);

        if (_paciente is null)
            throw new PacienteNotFoundException();

        return _paciente;
    }

    public int Create(NewPacienteInputModel medico)
    {
        var _paciente = new Paciente
        {
            Nome = medico.Nome,
            Cpf = medico.Cpf,
            DataNascimento = medico.DataNascimento
        };
        _context.Pacientes.Add(_paciente);

        _context.SaveChanges();

        return _paciente.PacienteId;

    }


    public void Delete(int id)
    {
        _context.Pacientes.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<PacienteViewModel> GetAll()
    {
        var _pacientes = _context.Pacientes.Select(m => new PacienteViewModel
        {
            PacienteId = m.PacienteId,
            Nome = m.Nome,
            Cpf = m.Cpf,
            DataNascimento = m.DataNascimento
        }).ToList();

        return _pacientes;
    }

    public PacienteViewModel GetByCpf(int cpf)
    {
        var _paciente = GetByCpf(cpf);

        var PacienteViewModel = new PacienteViewModel
        {
            PacienteId = _paciente.PacienteId,
            Nome = _paciente.Nome,
            Cpf = _paciente.Cpf,
            DataNascimento = _paciente.DataNascimento
        };
        return PacienteViewModel;
    }

    public PacienteViewModel GetById(int id)
    {
        var _paciente = GetByDbId(id);

        var PacienteViewModel = new PacienteViewModel
        {
            PacienteId = _paciente.PacienteId,
            Nome = _paciente.Nome,
            Cpf = _paciente.Cpf,
            DataNascimento = _paciente.DataNascimento
        };
        return PacienteViewModel;
    }

    public void Update(int id, NewPacienteInputModel medico)
    {
        var _paciente = GetByDbId(id);

        _paciente.Nome = medico.Nome;

        _context.Pacientes.Update(_paciente);

        _context.SaveChanges();
    }
}
