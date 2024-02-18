using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Application.ViewModels;

public class ServicoOrdemServicoViewModel
{
    public required ServicoViewModel Servico { get; set; }
    public required EnderecoViewModel Endereco { get; set; }
}
