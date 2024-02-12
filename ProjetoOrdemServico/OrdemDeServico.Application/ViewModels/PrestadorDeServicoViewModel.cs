using OrdemDeServico.Application.ViewModels;

namespace OrdemDeServico.Application;

public class PrestadorDeServicoViewModel
{
    public int PrestadorDeServicoId { get; set; }
    public required string Nome { get; set; }
    public required string Especialidade { get; set; }
    public required string Telefone { get; set; }
    public required EnderecoViewModel Endereco { get; set; }
}
