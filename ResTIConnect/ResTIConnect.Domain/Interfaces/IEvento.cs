using ResTIConnect.Domain.Entities;
namespace ResTIConnect.Domain.Interfaces;

public interface IEvento: IBaseRepository<Usuario>
{
   Task<Evento> GetById(int EventoId);
}
