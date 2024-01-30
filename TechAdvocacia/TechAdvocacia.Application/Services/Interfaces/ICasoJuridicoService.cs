using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Application.Services.Interfaces;
public interface ICasoJuridicoService
{
    public int Create(NewCasoJuridicoInputModel casoJuridico);
    public void Update(int id, NewCasoJuridicoInputModel casoJuridico);
    public void Delete(int id);
    public CasoJuridicoViewModel GetById(int id);
    public ICollection<CasoJuridicoViewModel> GetAll();
}
