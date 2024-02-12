namespace ResTIConnect.Domain.Entities;

public class Perfis : BaseEntity
{
    public int PerfilId { get; set; }
    public string? Descricao { get; set; }
    public required string Permissoes { get; set; }
    public ICollection<User>? Users { get; set; } = new List<User>();
}
