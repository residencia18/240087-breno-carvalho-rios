namespace OrdemDeServico.WebAPI.InputModels;

public class NewOrdemDeServicoInputModel
{
    public required string Descricao { get; set; }
    public required DateTime Data { get; set; }
    public required int PrestadorDeServico { get; set; }
    public required int Cliente { get; set; }
    public required string Status { get; set; }
}