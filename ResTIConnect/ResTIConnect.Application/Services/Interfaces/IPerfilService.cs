using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IPerfilService
    {

        public List<PerfilViewModel> GetAll();
        public PerfilViewModel? GetById(int id);
        public List<PerfilViewModel> GetByUserId(int userId);
        public int Create(NewPerfilInputModel perfil);
        public void Update(int id, NewPerfilInputModel perfil);
        public void Delete(int id);
    }
}
