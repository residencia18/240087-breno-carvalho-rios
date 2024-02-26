namespace ResTIConnect.Domain.Exceptions
{
    public class UsuarioNotFoundException : Exception
    {
        public UsuarioNotFoundException() :
           base("O usuário selecionado não foi encontrado.")
        {
        }
    }

    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException() : base("O email informado ja existe") { }
    }

    public class InvalidCredentialsException : Exception {
        public InvalidCredentialsException() : base("Email ou senha inválidos") { }
    }
}
