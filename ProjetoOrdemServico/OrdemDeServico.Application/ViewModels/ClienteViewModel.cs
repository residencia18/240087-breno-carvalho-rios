namespace OrdemDeServico.Application.ViewModels;

public class ClienteViewModel
{
    public int ClienteId { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required EnderecoViewModel Endereco { get; set; }
}
