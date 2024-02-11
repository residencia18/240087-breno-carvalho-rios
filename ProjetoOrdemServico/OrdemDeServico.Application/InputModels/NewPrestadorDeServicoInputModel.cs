namespace OrdemDeServico.Application.InputModels;
public class NewPrestadorDeServicoInputModel
{
    public required string Nome { get; set; }
    public required string Especialidade { get; set; }
    public required string Telefone { get; set; }
    public required NewEnderecoInputModel Endereco { get; set; }
}
