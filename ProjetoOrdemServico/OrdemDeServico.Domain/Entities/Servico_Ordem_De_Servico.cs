namespace OrdemDeServico.Domain.Entities;
public class Servico_Ordem_De_Servico : BaseEntity
    {
        public int Servico_Ordem_De_ServicoId { get; set; }

        public int Ordem_De_ServicoId { get; set; }

        public int ServicoId { get; set; }

        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
    }
