using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Domain;

public class Usuario : BaseEntity
{
    public int UsuarioId { get; set; }
    public required string NomeUsuario { get; set; }
    public required string Senha { get; set; }
}
