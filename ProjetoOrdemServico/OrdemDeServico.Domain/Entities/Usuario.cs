namespace OrdemDeServico.Domain.Entities;

public class Usuario : BaseEntity
{
    public int UsuarioId { get; set; }
    public required string NomeUsuario { get; set; }
    public required string Senha { get; set; }
    public Cliente? Cliente { get; set; }
    public PrestadorDeServico? PrestadorDeServico { get; set; }
}
