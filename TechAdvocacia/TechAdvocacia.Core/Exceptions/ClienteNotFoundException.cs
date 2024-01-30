namespace TechAdvocacia.Core.Exceptions;
public class ClienteNotFoundException : Exception
{
    public ClienteNotFoundException() : base("Cliente não encontrado!"){}
}
