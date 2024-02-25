namespace OrdemDeServico.Domain.Exceptions;

public class UsuarioAlreadyExistsException : Exception
{
    public UsuarioAlreadyExistsException() : base("Nome de usuário já existe") { }
}
