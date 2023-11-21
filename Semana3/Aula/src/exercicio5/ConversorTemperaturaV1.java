package exercicio5;

import java.util.Scanner;

public class ConversorTemperaturaV1 {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		System.out.println("Deseja converter de: ");
		System.out.println("1. Celsius");
		System.out.println("2. Fahrenheit");
		int op = scan.nextInt();
		
		System.out.println("Digite uma temperatura: ");
		float temperatura = scan.nextFloat();
		
		float novaTemperatura;
		switch (op) {
			case 1: {
				novaTemperatura = celsiusParaFahr(temperatura);
				System.out.println(temperatura + "° Celsius equivalem a " + novaTemperatura + "° Fahrenheit.");
				break;
			}
			case 2: {
				novaTemperatura = fahrParaCelsius(temperatura);
				System.out.println(temperatura + "° Fahrenheit equivalem a " + novaTemperatura + "° Celsius.");
				break;
			}
			default: {
				System.out.println("Opção Inválida");
			}
		}
		
		scan.close();
	}
	
	public static float celsiusParaFahr(float temperatura) {
		return (temperatura * 9/5) + 32;
	}
	
	public static float fahrParaCelsius(float temperatura) {
		return (temperatura - 32) * 5 / 9;
	}
}
