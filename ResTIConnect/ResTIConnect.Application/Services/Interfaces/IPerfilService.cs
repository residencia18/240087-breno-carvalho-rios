using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IPerfilService : IBaseService<NewPerfilInputModel, PerfilViewModel>
    {
        List<PerfilViewModel> GetByUserId(int userId);
    }
}
