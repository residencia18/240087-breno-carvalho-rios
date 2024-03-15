using Praticas.Exercicio01.Exceptions;

namespace Exercicio01;

public class ContaBancaria : IContaBancaria
{
    public double Saldo { get; private set; }

    public ContaBancaria()
    {
        Saldo = 0.0;
    }

    public double Depositar(double valor)
    {
        if (valor <= 0)
        {
            throw new ValorInvalidoException();
        }

        Saldo += valor;

        return Saldo;
    }

    public double Sacar(double valor)
    {
        if (valor <= 0)
        {
            throw new ValorInvalidoException();
        }

        if (Saldo < valor)
        {
            throw new SaldoInsuficienteException(Saldo);
        }

        Saldo -= valor;

        return Saldo;
    }

    public double Transferir(double valor, ContaBancaria contaBancaria)
    {
        Sacar(valor);
        contaBancaria.Depositar(valor);

        return Saldo;
    }
}
