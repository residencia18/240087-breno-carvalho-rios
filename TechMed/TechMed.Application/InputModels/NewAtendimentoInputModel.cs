namespace TechMed.Application.InputModels;

public class NewAtendimentoInputModel
{
    public required DateTimeOffset DataHoraInicio { get; set; }
    public required DateTimeOffset DataHoraFim { get; set; }
    public required string SuspeitaInicial { get; set; }
    public required string Diagnostico { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
}
