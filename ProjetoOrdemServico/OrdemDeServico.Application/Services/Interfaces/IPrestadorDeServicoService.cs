using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.Application.Services.Interfaces;

public interface IPrestadorDeServicoService : IBaseService<NewPrestadorDeServicoInputModel, PrestadorDeServicoViewModel>
{
    List<PrestadorDeServicoViewModel> GetByEspecialidade(string especialidade);
}
