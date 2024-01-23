namespace OrdemDeServico.Domain.Entities;
 public class Prestador_De_Servico : BaseEntity
    {
        
        public int Prestador_De_ServicoId { get; set; }

        public string Nome { get; set; }

        public string Especialidade { get; set; }

        public string Telefone { get; set; }
        public Endereco? Endereco { get; set; }

        
        public int EnderecoId { get; set; }

        
    }