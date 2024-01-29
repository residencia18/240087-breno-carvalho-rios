namespace OrdemDeServico.Domain.Entities;
public class Endereco : BaseEntity
    {
    
    

    public int EnderecoId { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }
        public string? Pais { get; set; }
         public Servico_Ordem_De_Servico? Servico_Ordem_De_Servico { get; set; }
         public int Prestador_De_ServicoId;

        public Ordem_De_Servico? Ordem_De_Servico { get; set; }
        public int Ordem_De_ServicoId { get; set; }
        public Prestador_De_Servico? Prestador_De_Servico { get; set; }
        
        
        
        
    }
