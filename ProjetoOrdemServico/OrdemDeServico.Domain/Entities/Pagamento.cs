using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Domain.Entities;

public class Pagamento : BaseEntity
{
    public int PagamentoId { get; set; }
    public required float Valor { get; set; }
    public required DateTimeOffset DataPagamento { get; set; }
    public required string MetodoPagamento { get; set; }
    public OrdemServico? OrdemServico { get; set; }
    public int OrdemServicoId { get; set; }
}
