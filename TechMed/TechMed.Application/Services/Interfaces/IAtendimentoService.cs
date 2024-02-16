using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;

namespace TechMed.Application.Services.InterfacesServices;

public interface IAtendimentoService : IBaseService<NewAtendimentoInputModel, AtendimentoViewModel, Atendimento>
{
   public List<AtendimentoViewModel> GetByPacienteId(int pacienteId);
   public List<AtendimentoViewModel> GetByMedicoId(int medicoId);
   public ICollection<AtendimentoViewModel> GetByDateInterval(DateTimeOffset dataInicial, DateTimeOffset dataFinal);

}
