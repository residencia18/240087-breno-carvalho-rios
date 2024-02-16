namespace ResTIConnect.Domain.Exceptions
{
    public class SistemaNotFoundException : Exception
    {
        public SistemaNotFoundException() : base("Sistema não encontrado.") { }
    }

    public class EmptyUsersListException : Exception
    {
        public EmptyUsersListException() : base("O sistema deve conter pelo menos um usuário") { }
    }
}
