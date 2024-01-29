namespace OrdemDeServico.Domain.Entities;
public class ServicoOrdemDeServico : BaseEntity
    {
        public int ServicoOrdemDeServicoId { get; set; }
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
    }
