using TechAdvocacia.Core.Entities.Common;
namespace TechAdvocacia.Core.Entities;
public class Advogado : BaseEntity
{
    public int AdvogadoId { get; set; }
    public required string Nome { get; set; }
    public ICollection<CasoJuridico>? CasosJuridicos { get; set; }
}
