using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Entities;
public class Sistema : BaseEntity
{
    public int SistemaId { get; set; }
    public required string Descricao { get; set; }
    public required string Tipo { get; set; }
    public required string EnderecoEntrada { get; set; }
    public required string EnderecoSaida { get; set; }
    public required string Protocolo { get; set; }
    public required DateTimeOffset DataHoraInicioIntegracao { get; set; }
    public required string Status { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
