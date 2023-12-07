namespace AvaliacaoDotNet;

public class CartaoCredito : IPagamento
{


   public string Descricao { get; set; } = "";
   public double ValorBruto { get; set; } = 0.00;
   public double Desconto { get; set; } = 0.00;
   public DateTime Data { get; set; } =  DateTime.Now;


   public CartaoCredito(string descricao,double valorBruto,double desconto,DateTime data){
      this.Descricao = descricao;
      this.ValorBruto = valorBruto;
      this.Desconto = desconto;
      this.Data = data;
   }
   public void RealizarPagamento(double valor)
   {
      Console.WriteLine($"Pagamento de {valor} realizado com cartão de crédito");
   }
}

// exemples double in c# ?
public class PagamentoEmDinheiro : IPagamento
{

   public string Descricao { get; set; } = "";
   public double ValorBruto { get; set; } = 0.00;
   public double Desconto { get; set; } = 0.00;
   public DateTime Data { get; set; } =  DateTime.Now;

   public PagamentoEmDinheiro(string descricao,double valorBruto,double desconto,DateTime data){
      this.Descricao = descricao;
      this.ValorBruto = valorBruto;
      this.Desconto = desconto;
      this.Data = data;
   }
   public void RealizarPagamento(double valor)
   {
      Console.WriteLine($"Pagamento de {valor} realizado em dinheiro");
   }
}
public class PagamentoEmPix : IPagamento
{

   public string Descricao { get; set; } = "";
   public double ValorBruto { get; set; } = 0.00;
   public double Desconto { get; set; } = 0.00;
   public DateTime Data { get; set; } =  DateTime.Now;

   public PagamentoEmPix(string descricao,double valorBruto,double desconto,DateTime data){
      this.Descricao = descricao;
      this.ValorBruto = valorBruto;
      this.Desconto = desconto;
      this.Data = data;
   }

   public void RealizarPagamento(double valor)
   {
      Console.WriteLine($"Pagamento de {valor} realizado com Pix");
   }
}