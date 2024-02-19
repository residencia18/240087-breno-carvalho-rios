using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.Application.Services.Interfaces;

public interface IOrdemServicoService : IBaseService<NewOrdemServicoInputModel, OrdemServicoViewModel>
{
    void AdicionaServico(int ordemServicoId, AddServicoIntoOrdemServicoInputModel servico);
    void RemoveServico(int ordemServicoId, int servicoId);
    void UpdateOrdemServico(int id, UpdateOrdemDeServicoInputModel ordemServico);
}
