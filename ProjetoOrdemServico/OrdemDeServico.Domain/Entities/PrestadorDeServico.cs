namespace OrdemDeServico.Domain.Entities;
public class PrestadorDeServico : BaseEntity
{
    public int PrestadorDeServicoId { get; set; }
    public required string Nome { get; set; }
    public required string Especialidade { get; set; }
    public required string Telefone { get; set; }
    public required Endereco Endereco { get; set; }
    public int EnderecoId { get; set; }
    public ICollection<OrdemServico>? OrdemServico { get; set; }
}
