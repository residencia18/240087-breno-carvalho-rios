namespace OrdemDeServico.Domain.Entities;
 public class Ordem_De_Servico : BaseEntity
    {
        
        public int Ordem_De_ServicoId { get; set; }

        public int Numero { get; set; }

        public string? Descricao { get; set; }

        public DateTime DataEmissao { get; set; }

        public string? Status { get; set; }

        public Endereco Endereco { get; set; }
    }
