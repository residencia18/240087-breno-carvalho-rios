namespace OrdemDeServico.Application.InputModels;

public class AddServicoIntoOrdemServicoInputModel
{
    public required int ServicoId { get; set; }
    public required NewEnderecoInputModel Endereco { get; set; }
}
