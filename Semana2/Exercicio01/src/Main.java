import conta.Conta;

public class Main {
	public static void main(String[] args) {
		Conta contaTeste = new Conta(1, "Breno Rios");
		contaTeste.deposita(50.00);
		contaTeste.saque(20.00);
		contaTeste.consulta();
	}
}
