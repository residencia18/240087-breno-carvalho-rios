using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using System.Collections.Generic;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IUserService
    {
       public List<UserViewModel> GetAll();
        public UserViewModel? GetById(int id);
        public List<UserViewModel> GetByPerfilId(int perfilId);
        public int Create(NewUserInputModel user);
        public void Update(int id, NewUserInputModel user);
        public void Delete(int id);
    }
}
