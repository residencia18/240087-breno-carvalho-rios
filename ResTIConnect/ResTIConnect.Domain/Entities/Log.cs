namespace ResTIConnect.Domain.Entities;

public class Log : BaseEntity
{
    public int LogId {get; set;}
    public string? Tipo {get; set;}
    public string? Descricao {get; set;}
    public  DateTime DataHoraEvento {get; set;}
    public string? Entidade {get; set;}
    public int TuplaId {get; set;}
}

