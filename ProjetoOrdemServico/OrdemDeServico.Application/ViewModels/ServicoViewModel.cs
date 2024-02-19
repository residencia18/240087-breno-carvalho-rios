namespace OrdemDeServico.Application.ViewModels;
public class ServicoViewModel
{
    public int ServicoId { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required float Precos { get; set; }
}
