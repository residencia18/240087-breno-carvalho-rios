using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IUsuarioService : IBaseService<NewUsuarioInputModel, UsuarioViewModel, Usuario>
    {
        List<UsuarioViewModel> GetBySistemaId(int sistemaId);
        List<UsuarioViewModel> GetByEstado(string estado);
        List<UsuarioViewModel> GetByPerfilId(int perfilId);
    }
}
