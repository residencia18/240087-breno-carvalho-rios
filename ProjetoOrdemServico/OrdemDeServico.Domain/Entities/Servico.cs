namespace OrdemDeServico.Domain.Entities;
public class Servico
{
    public int ServicoId { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required float Precos { get; set; }

    public ICollection<ServicoOrdemDeServico>? ServicoOrdemDeServico { get; set; }
}
