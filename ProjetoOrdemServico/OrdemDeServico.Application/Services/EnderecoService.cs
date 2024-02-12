using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Application;

public class EnderecoService : IEnderecoService
{
    public int Create(NewEnderecoInputModel cliente)
    {
        throw new NotImplementedException();
    }

    public ICollection<EnderecoViewModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public EnderecoViewModel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, NewEnderecoInputModel cliente)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Endereco MapEnderecoInputModelToEndereco(NewEnderecoInputModel endereco)
    {
        throw new NotImplementedException();
    }

    public EnderecoViewModel MapEnderecoToEnderecoViewModel(Endereco endereco)
    {
        throw new NotImplementedException();
    }
}
