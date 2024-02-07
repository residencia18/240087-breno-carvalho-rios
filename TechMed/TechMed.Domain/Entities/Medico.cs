using TechMed.Domain.Entities.Common;

namespace TechMed.Domain.Entities;
public class Medico : BaseEntity
{
    public int MedicoId { get; set; }
    public required string Nome { get; set; }
    public required string Crm { get; set; }
    public required string Cpf { get; set; }

    public ICollection<Atendimento>? Atendimentos { get; set; }
}
