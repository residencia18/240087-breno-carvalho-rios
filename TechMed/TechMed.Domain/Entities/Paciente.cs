using TechMed.Domain.Entities.Common;

namespace TechMed.Domain.Entities;
public class Paciente : BaseEntity
{
    public int PacienteId { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required DateTimeOffset DataNascimento { get; set; }

    public ICollection<Atendimento>? Atendimentos { get; set; }
}
