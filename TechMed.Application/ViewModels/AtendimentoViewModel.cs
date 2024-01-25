namespace TechMed.Application.ViewModels;
public class AtendimentoViewModel
{
    public int AtendimentoId { get; set; }
    public DateTime DataHora { get; set; }
    public MedicoViewModel Medico { get; set; }
    public PacienteViewModel Paciente { get; set; }
}
