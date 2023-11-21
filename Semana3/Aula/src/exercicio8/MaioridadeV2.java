package exercicio8;

import java.time.LocalDate;
import java.util.Scanner;

public class MaioridadeV2 {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		System.out.println("Digite o dia de nascimento: ");
		int dia = scan.nextInt();
		
		System.out.println("Digite o mes de nascimento: ");
		int mes = scan.nextInt();
		
		System.out.println("Digite o ano de nascimento: ");
		int ano = scan.nextInt();
		
		LocalDate nascimento = LocalDate.of(ano, mes, dia);
		LocalDate hoje = LocalDate.now();
		
		long idade = java.time.temporal.ChronoUnit.YEARS.between(nascimento, hoje);
		
		System.out.println(idade);
		
		scan.close();
	}
}
