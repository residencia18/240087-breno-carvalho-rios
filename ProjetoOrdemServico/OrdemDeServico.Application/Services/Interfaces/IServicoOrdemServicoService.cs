using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.Application.Services.Interfaces;

public interface IServicoOrdemServicoService : IBaseService<NewServicoOrdemServicoInputModel, ServicoOrdemServicoViewModel>
{
}
