namespace Banco;
public class ContaBancaria {
    private double saldo;
    public double Saldo {
        get {
            return saldo;
        }
        set {
            if (value < 0) {
                throw new ArgumentException("Saldo não pode ser negativo.");
            }
            saldo = value;
        }
    }
}
