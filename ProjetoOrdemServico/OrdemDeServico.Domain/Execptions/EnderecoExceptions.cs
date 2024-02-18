namespace OrdemDeServico.Domain.Exceptions;

public class EnderecoNotFoundException : Exception
{
    public EnderecoNotFoundException() : base("Endereço não encontrado") { }
}
