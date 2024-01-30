namespace ResTIConnect.Domain.Interfaces;
using ResTIConnect.Domain.Entities;
public interface ISistemas: IBaseRepository<Sistemas>
{
   Task<Sistemas> GetById(int SistemaId);
}

