namespace ResTIConnect.Domain.Entities;
public class Evento : BaseEntity
{
    public int EventoId { get; set; }
    public required string Tipo { get; set; }
    public required string Descricao { get; set; }
    public required string Codigo { get; set; }
    public required string Conteudo { get; set; }
    public required DateTimeOffset DataHoraOcorrencia { get; set; }
    public required ICollection<Sistema> Sistemas { get; set; }
}
