package conversortemperatura;

import java.util.Scanner;

public class ConversorTemperatura {
	public static void main(String[] args) {
		int op = 0;
		Scanner scanner = new Scanner(System.in);
		System.out.println("Digite a temperatura:");
		float temperatura = scanner.nextFloat();
		System.out.println("1. Celsius");
        System.out.println("2. Fahrenheit");
		
        do {
        	System.out.println("A temperatura está em Celsius ou Fahrenheit?");
            op = scanner.nextInt();
        } while (op < 1 || op > 4);		
		
		
		switch(op) {
	    	case 1:
	    		System.out.println(temperatura + "°C equivalem a " + celsiusParaFahrenheit(temperatura) + "°F");
	    		break;
	    	case 2:
	    		System.out.println(temperatura + "°F equivalem a " + fahrenheitParaCelsius(temperatura) + "°C");
	    		break;
	    	default:
	    		System.out.println("Opção Inválida!");
		}
		
		scanner.close();
	}
	
	public static float celsiusParaFahrenheit(float temperatura) {		
		return ((temperatura * 9 / 5) + 32);
	}
	
	public static float fahrenheitParaCelsius(float temperatura) {
		return ((temperatura - 32) / 9) * 5;
	}
}
