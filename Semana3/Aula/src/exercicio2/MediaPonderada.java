package exercicio2;

import java.util.Scanner;

public class MediaPonderada {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		float n1, n2, n3, p1, p2, p3;
		
		System.out.println("Digite a primeira nota: ");
		n1 = scan.nextFloat();
		System.out.println("Digite a segunda nota: ");
		n2 = scan.nextFloat();
		System.out.println("Digite a terceira nota: ");
		n3 = scan.nextFloat();
		
		System.out.println("Digite o peso da primeira nota: ");
		p1 = scan.nextFloat();
		System.out.println("Digite o peso da segunda nota: ");
		p2 = scan.nextFloat();
		System.out.println("Digite o peso da terceira nota: ");
		p3 = scan.nextFloat();
		
		System.out.println("A média das notas é: " + mediaPonderada(n1, n2, n3, p1, p2, p3));
		scan.close();
	}
	
	public static float mediaPonderada(float n1, float n2, float n3, float p1, float p2, float p3) {
		float media = ((n1 * p1) + (n2 * p2) + (n3 * p3)) / (p1 + p2 + p3);
		return media;
	}
}
