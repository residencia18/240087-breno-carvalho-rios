using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Exceptions;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;
public class AtendimentoService : BaseService, IAtendimentoService
{
   private readonly IMedicoService _medicoService;
   public AtendimentoService(ITechMedContext context, IMedicoService medico) : base(context)
   {
      _medicoService = medico;
   }
   public int Create(NewAtendimentoInputModel atendimento)
   {
      return _medicoService.CreateAtendimento(atendimento.MedicoId, atendimento);
   }
   public List<AtendimentoViewModel> GetAll()
   {
      return _context.AtendimentosCollection.GetAll().Select(a => new AtendimentoViewModel
      {
         AtendimentoId = a.AtendimentoId,
         DataHora = a.DataHora,
         Medico = new MedicoViewModel
         {
            MedicoId = a.Medico.MedicoId,
            Nome = a.Medico.Nome
         },
         Paciente = new PacienteViewModel
         {
            PacienteId = a.Paciente.PacienteId,
            Nome = a.Paciente.Nome
         }
      }).ToList();
   }

   public AtendimentoViewModel? GetById(int id)
   {
      var atendimento = _context.AtendimentosCollection.GetById(id);
      if (atendimento is null)
      {
         return null;
      }
      return new AtendimentoViewModel
      {
         AtendimentoId = atendimento.AtendimentoId,
         DataHora = atendimento.DataHora,
         Medico = new MedicoViewModel
         {
            MedicoId = atendimento.Medico.MedicoId,
            Nome = atendimento.Medico.Nome
         },
         Paciente = new PacienteViewModel
         {
            PacienteId = atendimento.Paciente.PacienteId,
            Nome = atendimento.Paciente.Nome
         }
      };
   }

   public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
   {
      throw new NotImplementedException();
   }

   public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
   {
      throw new NotImplementedException();
   }
}
