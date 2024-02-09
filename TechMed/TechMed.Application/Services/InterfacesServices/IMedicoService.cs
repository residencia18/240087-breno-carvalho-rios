using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.InterfacesServices;

public interface IMedicoService
{
    public List<MedicoViewModel> GetAll();
    public MedicoViewModel GetById(int id);
    public MedicoViewModel GetByCrm(string crm);
    public void Create(NewMedicoInputModel medico);
    public void Update(NewMedicoInputModel medico);
    public void Delete(int id);
}
