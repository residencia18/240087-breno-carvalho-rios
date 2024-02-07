using TechMed.Domain.Entities.Common;

namespace TechMed.Domain.Entities;
public class Atendimento : BaseEntity
{
    public int AtendimentoId { get; set; }
    public required DateTimeOffset DataHoraInicio { get; set; }
    public required DateTimeOffset DataHoraFim { get; set; }
    public required string SuspeitaInicial { get; set; }
    public required string Diagnostico { get; set; }

    public Medico? Medico { get; set; }
    public required int MedicoId { get; set; }
    public Paciente? Paciente { get; set; }
    public required int PacienteId { get; set; }
    public ICollection<Exame>? Exames { get; set; }
}
