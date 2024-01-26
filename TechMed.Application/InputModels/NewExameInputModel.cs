namespace TechMed.Application.InputModels;
public class NewExameInputModel
{
    public string? Nome { get; set; }
    public DateTimeOffset DataHora { get; set; }
    public int AtendimentoId { get; set; }
}
