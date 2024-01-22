
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Interfaces;

public interface IPerfil: IBaseRepository<Perfil>
{
   Task<Perfil> GetById(int PerfilId);
}

