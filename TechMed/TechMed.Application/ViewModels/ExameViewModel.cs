using TechMed.Application.ViewModels;

namespace TechMed.Application;

public class ExameViewModel
{
    public int ExameId { get; set; }
    public required string Nome { get; set; }
    public required float Valor { get; set; }
    public required string Local { get; set; }
    public required DateTimeOffset DataHora { get; set; }
    public required string ResultadoDescricao { get; set; }
    public AtendimentoViewModel Atendimento { get; set; } = null!;

}
