package exercicio5;

import java.util.Scanner;

public class ConversorTemperaturaV2 {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		System.out.println("Deseja converter de: ");
		System.out.println("1. Celsius");
		System.out.println("2. Fahrenheit");
		int op = scan.nextInt();
		
		if(op < 1 || op > 2) {
			System.out.println("Opção Inválida!");
			scan.close();
			return;
		}
		
		System.out.println("Digite uma temperatura: ");
		float temperatura = scan.nextFloat();
		
		System.out.println("Temperatura Convertida: " + conversorTemperatura(temperatura, op) + "°");
		scan.close();
	}
	
	public static float conversorTemperatura(float temperatura, int op) {
		float temperaturaConvertida = 0;
		
		switch (op) {
			case 1: {
				temperaturaConvertida = (temperatura * 9/5) + 32;
				break;
			}
			case 2: {
				temperaturaConvertida = (temperatura - 32) * 5 / 9;
				break;
			}
		}
		
		return temperaturaConvertida;
	}
}
