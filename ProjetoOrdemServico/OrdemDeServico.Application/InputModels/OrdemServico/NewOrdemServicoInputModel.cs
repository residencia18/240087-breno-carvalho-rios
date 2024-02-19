namespace OrdemDeServico.Application.InputModels;

public class NewOrdemServicoInputModel
{
    public required int Numero { get; set; }
    public string? Descricao { get; set; }
    public required DateTimeOffset DataDeEmissao { get; set; }
    public required string Status { get; set; }
    public int ClienteId { get; set; }
    public int PrestadorDeServicoId { get; set; }
    public required ICollection<AddServicoIntoOrdemServicoInputModel> Servicos { get; set; }
}
