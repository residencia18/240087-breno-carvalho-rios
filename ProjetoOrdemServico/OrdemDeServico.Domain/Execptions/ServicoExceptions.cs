namespace OrdemDeServico.Domain.Exceptions;

public class ServicoNotFoundException : Exception
{
    public ServicoNotFoundException() : base("Serviço não encontrado") { }
}
