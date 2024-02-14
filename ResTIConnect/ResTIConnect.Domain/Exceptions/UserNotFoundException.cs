namespace ResTIConnect.Domain.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("O Usuário selecionado não foi encontrado.") { }
}
