using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;

namespace TechAdvocacia.Application.Services.Interfaces;
public interface ICasoJuridicoService
{
    public int Create(NewCasoJuridicoInputModel casoJuridico);
    public void Update(int id, NewCasoJuridicoInputModel casoJuridico);
    public void Delete(int id);
    public CasoJuridicoViewModel GetById(int id);
    public List<CasoJuridicoViewModel> GetAll();
}
