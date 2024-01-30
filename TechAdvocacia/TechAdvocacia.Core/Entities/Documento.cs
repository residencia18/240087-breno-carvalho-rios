using TechAdvocacia.Core.Entities.Common;

namespace TechAdvocacia.Core.Entities;
public class Documento : BaseEntity
{
    public int DocumentoId { get; set; }
    public required string Descricao { get; set; }
    public int CasoJuridicoId { get; set; }
    public required CasoJuridico CasoJuridico { get; set; }
}
