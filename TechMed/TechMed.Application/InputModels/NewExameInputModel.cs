namespace TechMed.Application.InputModels;

public class NewExameInputModel
{
    public required string Nome { get; set; }
    public required float Valor { get; set; }
    public required string Local { get; set; }
    public required DateTimeOffset DataHora { get; set; }
    public required string ResultadoDescricao { get; set; }
    public required int AtendimentoId { get; set; }
}
