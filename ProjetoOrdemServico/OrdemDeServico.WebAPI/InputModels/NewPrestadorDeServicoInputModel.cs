namespace OrdemDeServico.WebAPI.InputModels.NewPrestadorDeServicoInputModel;

public class NewPrestadorDeServicoInputModel
{
    public int PrestadorDeServicoId { get; set; }
    public required string Nome { get; set; }
    public required string Especialidade { get; set; }
    public required string Telefone { get; set; }
    public required NewEnderecoInputModel Endereco { get; set; }
}
