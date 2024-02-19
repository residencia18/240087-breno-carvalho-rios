namespace OrdemDeServico.Application.InputModels;
public class NewServicoOrdemServicoInputModel
{
    public int ServicoId { get; set; }
    public int OrdemServicoId { get; set; }
    public required NewEnderecoInputModel Endereco { get; set; }

}
