package exercicio3;

import java.util.Scanner;

public class ConcatenarString {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		System.out.println("Digite a primeira string: ");
		String s1 = scan.nextLine();
		
		System.out.println("Digite a primeira string: ");
		String s2 = scan.nextLine();
		
		System.out.println("A string concatenada é: ");
		String s3 = concatString(s1, s2);
		System.out.println(s3);
		scan.close();
	}
	
	public static String concatString(String s1, String s2) {
		return s1 + s2;
	}
}
