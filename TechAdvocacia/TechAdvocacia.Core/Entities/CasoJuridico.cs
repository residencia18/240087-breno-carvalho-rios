using TechAdvocacia.Core.Entities.Common;

namespace TechAdvocacia.Core.Entities;
public class CasoJuridico : BaseEntity
{
    public int CasoJuridicoId { get; set; }
    public required string Status { get; set; }
    public int AdvogadoId { get; set; }
    public int ClienteId { get; set; }
    public ICollection<Documento>? Documentos { get; set; }
    public Cliente? Cliente { get; set; }
    public Advogado? Advogado { get; set; }
}
