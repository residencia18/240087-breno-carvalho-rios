using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.Application.Services.Interfaces;

public interface IPagamentoService : IBaseService<NewPagamentoInputModel, PagamentoViewModel>
{
    List<PagamentoViewModel> GetPagamentoByMetodo(string metodoPagamento);
}
