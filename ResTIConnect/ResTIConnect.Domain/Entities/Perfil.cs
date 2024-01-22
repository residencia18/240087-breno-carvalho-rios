namespace ResTIConnect.Domain.Entities;

public class Perfil : BaseEntity
{
    public int PerfilId { get; set; }
    public string Descricao { get; set; }
    public string Permissoes { get; set; }
}
