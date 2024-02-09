using TechMed.Application.InputModels;
using TechMed.Application.Services.InterfacesServices;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services;

public class MedicoService : IMedicoService
{
    private readonly IMedicoCollection _medico;
    public MedicoService(ITechMedDbContext dbContext)
    {

    }
    public void Create(NewMedicoInputModel medico)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<MedicoViewModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public MedicoViewModel GetByCrm(string crm)
    {
        throw new NotImplementedException();
    }

    public MedicoViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(NewMedicoInputModel medico)
    {
        throw new NotImplementedException();
    }
}
