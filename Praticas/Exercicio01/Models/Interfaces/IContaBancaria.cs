namespace Praticas.Exercicio01.Models.Interfaces;
public interface IContaBancaria
{
    double Depositar(double valor);
    double Sacar(double valor);
    double Transferir(double valor, ContaBancaria contaBancaria);
}
