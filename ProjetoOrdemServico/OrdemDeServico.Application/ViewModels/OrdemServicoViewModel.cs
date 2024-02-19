namespace OrdemDeServico.Application.ViewModels;

public class OrdemServicoViewModel
{
    public int OrdemServicoId { get; set; }
    public required int Numero { get; set; }
    public string? Descricao { get; set; }
    public required DateTimeOffset DataDeEmissao { get; set; }
    public required string Status { get; set; }
    public required ClienteViewModel Cliente { get; set; }
    public required PrestadorDeServicoViewModel PrestadorDeServico { get; set; }
    public ICollection<ServicoOrdemServicoViewModel> Servicos { get; set; } = new List<ServicoOrdemServicoViewModel>();
    public ICollection<PagamentoViewModel> Pagamentos { get; set; } = new List<PagamentoViewModel>();
}
