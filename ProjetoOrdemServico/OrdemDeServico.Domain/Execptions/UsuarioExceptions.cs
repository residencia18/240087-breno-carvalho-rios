namespace OrdemDeServico.Domain.Exceptions;

public class UsuarioAlreadyExistsException : Exception
{
    public UsuarioAlreadyExistsException() : base("Nome de usuário já existe") { }
}

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() : base("Nome de usuário ou senha incorretos") { }
}
