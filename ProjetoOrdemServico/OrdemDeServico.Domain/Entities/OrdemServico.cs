using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Domain.Entities;

public class OrdemServico : BaseEntity
{
    public int OrdemServicoId { get; set; }
    public required int Numero { get; set; }
    public string? Descricao { get; set; }
    public required DateTimeOffset DataDeEmissao { get; set; }
    public required string Status { get; set; }
    public int ClienteId { get; set; }
    public int PrestadorDeServicoId { get; set; }
    public Cliente? Cliente { get; set; }
    public PrestadorDeServico? PrestadorDeServico { get; set; }
    public ICollection<Pagamento>? Pagamentos { get; set; }
    public ICollection<ServicoOrdemServico>? ServicoOrdemServico { get; set; }

}
