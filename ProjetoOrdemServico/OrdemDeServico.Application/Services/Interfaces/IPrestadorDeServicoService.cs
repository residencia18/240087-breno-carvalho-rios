using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Application.Services.Interfaces;

public interface IPrestadorDeServicoService : IBaseService<NewPrestadorDeServicoInputModel, PrestadorDeServicoViewModel>
{
    public PrestadorDeServico MapPrestadorDeServicoInputModelToPrestadorDeServico(NewPrestadorDeServicoInputModel prestadorDeServico);
    public PrestadorDeServicoViewModel MapPrestadorDeServicoToPrestadorDeServicoViewModel(PrestadorDeServico prestadorDeServico);
}
