using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Application.Services.Interfaces;

public interface IClienteService : IBaseService<NewClienteInputModel, ClienteViewModel>
{
    List<ClienteViewModel> GetByTelefone(string telefone);
}
