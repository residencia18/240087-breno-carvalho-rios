using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Application.Services.Interfaces;
public interface IClienteService
{
    public int Create(NewClientInputModel client);
    public void Update(int id, NewClientInputModel client);
    public void Delete(int id);
    public ClienteViewModel GetById(int id);
    public ICollection<ClienteViewModel> GetAll();
}
