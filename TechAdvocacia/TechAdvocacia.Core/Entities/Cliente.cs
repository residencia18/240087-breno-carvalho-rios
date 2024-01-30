using TechAdvocacia.Core.Entities.Common;

namespace TechAdvocacia.Core.Entities;
public class Cliente : BaseEntity
{
    public int ClienteId { get; set; }
    public required string Nome { get; set; }
    public ICollection<CasoJuridico>? CasoJuridicos { get; set; }
}
