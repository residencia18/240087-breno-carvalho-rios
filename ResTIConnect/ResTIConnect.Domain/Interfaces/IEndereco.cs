namespace ResTIConnect.Domain.Interfaces;
using ResTIConnect.Domain.Entities;
public interface IEndereco: IBaseRepository<Endereco>
{
   Task<Endereco> GetById(int EnderecoId);
}

