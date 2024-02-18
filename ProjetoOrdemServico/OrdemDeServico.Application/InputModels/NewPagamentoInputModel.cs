namespace OrdemDeServico.Application.InputModels;
public class NewPagamentoInputModel
{
    public required float Valor { get; set; }
    public required DateTime DataPagamento { get; set; }
    public required string MetodoPagamento { get; set; }
    public required int OrdemServicoId { get; set; }
}
