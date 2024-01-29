namespace OrdemDeServico.Domain.Entities;
public class Cliente : BaseEntity
{
    public int ClienteId { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required Endereco Endereco { get; set; }
    public int EnderecoId { get; set; }
    public ICollection<OrdemServico>? OrdemServico { get; set; }
}
