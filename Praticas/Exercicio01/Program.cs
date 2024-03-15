using System.Globalization;
using Exercicio01;
using Praticas.Exercicio01.Exceptions;

CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

ContaBancaria c1 = new ContaBancaria();
ContaBancaria c2 = new ContaBancaria();

Console.WriteLine($"Depositando 1000 na conta c1");
Console.WriteLine($"Novo saldo em c1: {c1.Depositar(1000).ToString("C", CultureInfo.CurrentCulture)}\n");

Console.WriteLine($"Depositando 1500 na conta c2");
Console.WriteLine($"Novo saldo em c2: {c2.Depositar(1000).ToString("C", CultureInfo.CurrentCulture)}\n");

Console.WriteLine($"Sacando 500 da conta c1");
Console.WriteLine($"Novo saldo em c1: {c1.Sacar(500).ToString("C", CultureInfo.CurrentCulture)}\n");

Console.WriteLine($"Transferindo 1000 da conta c2 para c1");
Console.WriteLine($"Novo saldo em c1: {c1.Saldo.ToString("C", CultureInfo.CurrentCulture)}");
Console.WriteLine($"Novo saldo em c2: {c2.Transferir(750, c1).ToString("C", CultureInfo.CurrentCulture)}\n");

try
{
    Console.WriteLine($"Tentando sacar 10.000 da conta c1");
    Console.WriteLine($"Novo saldo em c1: {c1.Sacar(10000).ToString("C", CultureInfo.CurrentCulture)}\n");
}
catch (ValorInvalidoException e)
{
    Console.WriteLine(e.Message);
}
catch (SaldoInsuficienteException e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine($"Tentando sacar -500 da conta c1");
    Console.WriteLine($"Novo saldo em c1: {c1.Sacar(-500).ToString("C", CultureInfo.CurrentCulture)}\n");
}
catch (ValorInvalidoException e)
{
    Console.WriteLine(e.Message);
}
catch (SaldoInsuficienteException e)
{
    Console.WriteLine(e.Message);
}
