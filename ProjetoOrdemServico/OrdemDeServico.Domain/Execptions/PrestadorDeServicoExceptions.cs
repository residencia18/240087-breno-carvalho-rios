namespace OrdemDeServico.Domain.Exceptions;

public class PrestadorDeServicoNotFoundException : Exception
{
    public PrestadorDeServicoNotFoundException() : base("Prestador de Serviço não encontrado") { }
}
