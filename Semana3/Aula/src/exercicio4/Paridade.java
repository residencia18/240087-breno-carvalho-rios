package exercicio4;

import java.util.Scanner;

public class Paridade {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		System.out.println("Digite um número: ");
		int n1 = scan.nextInt();
		
		System.out.println("O número " + n1 + " é " + (ePar(n1) ? "par" : "ímpar"));
		scan.close();
	}
	
	public static boolean ePar(int numero) {
		return (numero % 2 == 0);
	}
}
