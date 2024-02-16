namespace OrdemDeServico.Application.ViewModels;
public class ServicoViewModel
    {
        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Precos { get; set; }
        public ICollection<ServicoOrdemServicoViewModel> ServicosOrdemServico { get; set; }
    }