namespace AvaliacaoDotNet;

public interface IPagamento
{
    public string Descricao { get; set; }
    public double ValorBruto { get; set; }
    public double Desconto { get; set; }
    public DateTime Data { get; set; }
    public void RealizarPagamento(double valor);
}