namespace AvaliacaoDotNet;

public class CartaoCredito : IPagamento{
   public string NumeroCartao { get; set; }
   public void RealizarPagamento(double valor){
      Console.WriteLine($"Pagamento de {valor} realizado com cartão de crédito");
   }
}

public class PagamentoEmDinheiro : IPagamento{
   public void RealizarPagamento(double valor){
      Console.WriteLine($"Pagamento de {valor} realizado em dinheiro");
   }
}
public class PagamentoEmPix : IPagamento{
   public void RealizarPagamento(double valor){
      Console.WriteLine($"Pagamento de {valor} realizado com Pix");
   }
}