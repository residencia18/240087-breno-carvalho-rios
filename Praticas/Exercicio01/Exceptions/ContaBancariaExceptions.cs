using System.Globalization;

namespace Praticas.Exercicio01.Exceptions;

public class ValorInvalidoException : Exception
{
    public ValorInvalidoException() : base("O valor utilizado na operação deve ser maior que zero") { }
}

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException(double saldo) : base($"Saldo insuficiente: R$ {saldo.ToString("C", CultureInfo.CurrentCulture)}") { }
}
