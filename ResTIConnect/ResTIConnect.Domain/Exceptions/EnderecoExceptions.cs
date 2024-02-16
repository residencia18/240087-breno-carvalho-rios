namespace ResTIConnect.Domain.Exceptions;

public class EnderecoNotFoundException : Exception
{
    public EnderecoNotFoundException() : base("O endereço selecionado não foi encontrado.") { }
}