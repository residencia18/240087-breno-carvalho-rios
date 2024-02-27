namespace ResTIConnect.Domain.Entities;

public class Perfil : BaseEntity
{
    public int PerfilId { get; set; }
    public string? Descricao { get; set; }
    public required string Permissoes { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }

}
