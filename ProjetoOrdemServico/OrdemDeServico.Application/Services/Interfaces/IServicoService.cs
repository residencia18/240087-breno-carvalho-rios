using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.Application.Services.Interfaces;
public interface IServicoService : IBaseService<NewServicoInputModel, ServicoViewModel>
{
    List<ServicoViewModel> GetByNome(string nome);
}
