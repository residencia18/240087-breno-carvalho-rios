
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Interfaces;

public interface IUsuario: IBaseRepository<Usuario>
{
   Task<Usuario> GetById(int UsuarioId);
}

