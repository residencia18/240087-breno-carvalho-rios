using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Application.Services.Interfaces;
public interface IAdvogadoService
{
    public int Create(NewAdvogadoInputModel advogado);
    public void Update(int id, NewAdvogadoInputModel advogado);
    public void Delete(int id);
    public AdvogadoViewModel GetById(int id);
    public ICollection<AdvogadoViewModel> GetAll();
}
