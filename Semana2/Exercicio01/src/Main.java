import conta.Conta;
import java.util.Scanner;

public class Main {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		
		int numero;
		String nome;

		System.out.println("Digite o número da conta: ");
		numero = Integer.parseInt(scanner.nextLine());
		
		System.out.println("Digite o nome do titular da conta: ");
		nome = scanner.nextLine();
		
		Conta contaTeste = new Conta(numero, nome);
		contaTeste.deposita(50.00);
		contaTeste.saque(20.00);
		contaTeste.consulta();
	}
}
