namespace OrdemDeServico.Domain.Entities;
public class ServicoOrdemDeServico : BaseEntity
{
    public int ServicoOrdemDeServicoId { get; set; }
    public int ServicoId { get; set; }
    public int OrdemDeServicoId { get; set; }
    public int EnderecoId { get; set; }
    public Endereco? Endereco { get; set; }
    public Servico? Servico { get; set; }
    public OrdemServico? OrdemServico { get; set; }
}
