namespace OrdemDeServico.Domain.Entities;

public abstract class BaseEntity
{
    public DateTime CretedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


}
