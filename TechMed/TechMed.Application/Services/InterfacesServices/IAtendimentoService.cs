using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.InterfacesServices;

public interface IAtendimentoService
{
   public List<AtendimentoViewModel> GetAll();
   public AtendimentoViewModel GetById(int id);
   public List<AtendimentoViewModel> GetByPacienteId(int pacienteId);
   public List<AtendimentoViewModel> GetByMedicoId(int medicoId);

   public int Create(NewAtendimentoInputModel atendimento);
   public void Update(int id, NewAtendimentoInputModel atendimento);
   public void Delete(int id);
   public ICollection<AtendimentoViewModel> GetByDateInterval(DateTimeOffset dataInicial, DateTimeOffset dataFinal);
   
}
