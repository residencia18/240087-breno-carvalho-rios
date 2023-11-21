package exercicio8;

import java.util.Scanner;

public class MaioridadeV1 {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		System.out.println("Digite a idade: ");
		int idade = scan.nextInt();
		
		System.out.println("A pessoa é " + (idade >= 18 ? "maior" : "menor") + " de idade");
		
		scan.close();
	}
}
