using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Application;

public interface IEnderecoService : IBaseService<NewEnderecoInputModel, EnderecoViewModel>
{
    public Endereco MapEnderecoInputModelToEndereco(NewEnderecoInputModel endereco);
    public EnderecoViewModel MapEnderecoToEnderecoViewModel(Endereco endereco);
}
