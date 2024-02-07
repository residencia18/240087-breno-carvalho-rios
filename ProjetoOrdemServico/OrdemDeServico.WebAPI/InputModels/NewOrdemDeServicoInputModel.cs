namespace OrdemDeServico.WebAPI.InputModels;

public class NewOrdemDeServicoInputModel
{
    public required string Descricao { get; set; }
    public required DateTime Data { get; set; }
    public required NewPrestadorDeServicoInputModel PrestadorDeServico { get; set; }
    public required string Status { get; set; }
}