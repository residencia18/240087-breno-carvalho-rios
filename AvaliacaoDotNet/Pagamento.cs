namespace AvaliacaoDotNet;

public class CartaoCredito : IPagamento
{


   public string Descricao { get; set; } = "";
   public double ValorBruto { get; set; } = 0.00;
   public double Desconto { get; set; } = 0.00;
   public DateTime Data { get; set; } =  DateTime.Now;


   public CartaoCredito(string descricao,double valorBruto,double desconto){
      this.Descricao = descricao;
      this.ValorBruto = valorBruto;
      this.Desconto = desconto;
   }
   public void RealizarPagamento(double valor)
   {
      Console.WriteLine($"Pagamento de {valor} realizado com cartão de crédito");
   }

   public override string ToString(){
      return $"Pagamento no valor de R${ValorBruto - Desconto:C2} na data: {Data.ToShortDateString()}! Descrição: {Descricao}";
   }
}

// exemples double in c# ?
public class PagamentoEmDinheiro : IPagamento
{

   public string Descricao { get; set; } = "";
   public double ValorBruto { get; set; } = 0.00;
   public double Desconto { get; set; } = 0.00;
   public DateTime Data { get; set; } =  DateTime.Now;

   public PagamentoEmDinheiro(string descricao,double valorBruto,double desconto){
      this.Descricao = descricao;
      this.ValorBruto = valorBruto;
      this.Desconto = desconto;
   }
   public void RealizarPagamento(double valor)
   {
      Console.WriteLine($"Pagamento de {valor} realizado em dinheiro");
   }
   public override string ToString(){
      return $"Pagamento no valor de R${ValorBruto - Desconto:C2} na data: {Data.ToShortDateString()}! Descrição: {Descricao}";
   }
}
public class PagamentoEmPix : IPagamento
{

   public string Descricao { get; set; } = "";
   public double ValorBruto { get; set; } = 0.00;
   public double Desconto { get; set; } = 0.00;
   public DateTime Data { get; set; } =  DateTime.Now;

   public PagamentoEmPix(string descricao,double valorBruto,double desconto){
      this.Descricao = descricao;
      this.ValorBruto = valorBruto;
      this.Desconto = desconto;
   }

   public void RealizarPagamento(double valor)
   {
      Console.WriteLine($"Pagamento de {valor} realizado com Pix");
   }
   public override string ToString(){
      return $"Pagamento no valor de R${ValorBruto - Desconto:C2} na data: {Data.ToShortDateString()}! Descrição: {Descricao}";
   }
}