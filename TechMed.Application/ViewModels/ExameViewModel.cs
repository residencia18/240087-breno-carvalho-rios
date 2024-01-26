namespace TechMed.Application.ViewModels;
public class ExameViewModel
{
    public string? Nome { get; set; }
    public DateTimeOffset DataHora { get; set; }
    public AtendimentoViewModel? Atendimento { get; set; }
}
