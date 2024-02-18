namespace OrdemDeServico.Application;

public class UpdateOrdemDeServicoInputModel
{
    public required int Numero { get; set; }
    public string? Descricao { get; set; }
    public required DateTimeOffset DataDeEmissao { get; set; }
    public required string Status { get; set; }
    public int ClienteId { get; set; }
    public int PrestadorDeServicoId { get; set; }
}
