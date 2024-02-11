
namespace ResTIConnect.Domain.Entities;

public class User : BaseEntity
{
    public int UserId { get; set; }
    public required string Name { get; set; }
    public string? Apelido { get; set; }
    public required string Senha { get; set; }
    public required string Telefone { get; set; }
    public Endereco? Endereco { get; set; }
    public required ICollection<Perfis> Perfis { get; set; }
    public required ICollection<Sistema> Sistemas { get; set; }
}
