namespace ResTIConnect.Domain.Entities;
public class Sistemas : BaseEntity
{
    public int SistemaId { get; set; }
    public string? Descricao { get; set; }
    public required string Tipo { get; set; }
    public required string EnderecoEntrada { get; set; }
    public required string EnderecoSaida { get; set; }
    public required string Protocolo { get; set; }
    public required DateTimeOffset DataHoraInicioIntegracao { get; set; }
    public required string Status { get; set; }
    public ICollection<Usuario>? Usuarios { get; set; }
    public ICollection<Evento>? Eventos { get; set; }
}
