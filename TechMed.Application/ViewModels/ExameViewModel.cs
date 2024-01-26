namespace TechMed.Application.ViewModels;
public class ExameViewModel
{
    public int ExameId { get; set; }
    public string? Nome { get; set; }
    public DateTimeOffset DataHora { get; set; }
    public AtendimentoViewModel? Atendimento { get; set; }
}
