using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;

namespace TechMed.Application.Services.InterfacesServices;

public interface IMedicoService : IBaseService<NewMedicoInputModel, MedicoViewModel, Medico>
{
    public MedicoViewModel GetByCrm(string crm);
    public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento);
}
