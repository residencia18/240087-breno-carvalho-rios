namespace OrdemDeServico.Domain;

public class OrdemServicoNotFoundException : Exception
{
    public OrdemServicoNotFoundException() : base("Ordem de Serviço não encontrada") { }
}
