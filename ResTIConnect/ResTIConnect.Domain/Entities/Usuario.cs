
namespace ResTIConnect.Domain.Entities;

public class Usuario : BaseEntity
{
    public int UsuarioId { get; set; }
    public required string Nome { get; set; }
    public string? Apelido { get; set; }
    public required string Senha { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }   
    public int EnderecoId { get; set; }
    public required Endereco Endereco { get; set; }
    public ICollection<Perfil>? Perfis { get; set; }
    public ICollection<Sistema>? Sistemas { get; set; }
}
