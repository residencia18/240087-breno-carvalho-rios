namespace Exercicio01;

public interface IContaBancaria
{
    double Depositar(double valor);
    double Sacar(double valor);
    double Transferir(double valor, ContaBancaria contaBancaria);
}
