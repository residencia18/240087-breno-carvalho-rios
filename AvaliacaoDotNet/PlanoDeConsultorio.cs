namespace AvaliacaoDotNet;

public class PlanoDeConsultorio
{
    public string Titulo { get; }
    public double ValorPorMes { get; }
    public List<string> Beneficios { get; }

    public PlanoDeConsultorio(string titulo, double valorPorMes, List<string> beneficios)
    {
        Titulo = titulo;
        ValorPorMes = valorPorMes;
        Beneficios = beneficios;
    }
}