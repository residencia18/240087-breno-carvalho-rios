namespace ResTIConnect.Domain.Entities;
public class Evento : BaseEntity
{
    public int EventoId { get; set; }
    public string? Tipo { get; set; }
    public string? Descricao { get; set; }
    public string? Codigo { get; set; }
    public string? Conteudo { get; set; }
    public DateTimeOffset DataHoraOcorrencia { get; set; }
}
