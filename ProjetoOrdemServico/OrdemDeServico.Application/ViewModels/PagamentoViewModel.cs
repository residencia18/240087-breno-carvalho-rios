namespace OrdemDeServico.Application.ViewModels;

public class PagamentoViewModel
{
    public int PagamentoId { get; set; }
    public required float Valor { get; set; }
    public required DateTimeOffset DataPagamento { get; set; }
    public required string MetodoPagamento { get; set; }
}
