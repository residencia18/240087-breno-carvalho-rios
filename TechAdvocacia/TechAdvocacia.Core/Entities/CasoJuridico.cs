using TechAdvocacia.Core.Entities.Common;

namespace TechAdvocacia.Core.Entities;
public class CasoJuridico : BaseEntity
{
    public int CasoJuridicoId { get; set; }
    public required float ChanceSucesso { get; set; }
    public required string Status { get; set; }
    public int AdvogadoId { get; set; }
    public int ClienteId { get; set; }
    public required ICollection<Documento> Documentos { get; set; }
    public required Cliente Cliente { get; set; }
    public required Advogado Advogado { get; set; }
}
