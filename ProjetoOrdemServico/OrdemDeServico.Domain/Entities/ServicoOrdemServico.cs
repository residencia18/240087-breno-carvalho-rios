namespace OrdemDeServico.Domain.Entities;
public class ServicoOrdemServico : BaseEntity
{
    public int ServicoOrdemServicoId { get; set; }
    public int ServicoId { get; set; }
    public int OrdemServicoId { get; set; }
    public int EnderecoId { get; set; }
    public Endereco? Endereco { get; set; }
    public Servico? Servico { get; set; }
    public OrdemServico? OrdemServico { get; set; }
}
