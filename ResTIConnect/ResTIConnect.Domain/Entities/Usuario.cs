namespace ResTIConnect.Domain.Entities;

public class Usuario : BaseEntity
{
    public int UsuarioId { get; set; }
    public required string Nome { get; set; }
    public string? Apelido { get; set; }
    public required string Senha { get; set; }
    public required string Telefone { get; set; }
    public required Endereco Endereco { get; set; }
    public required ICollection<Perfil> Perfil { get; set; }
}
