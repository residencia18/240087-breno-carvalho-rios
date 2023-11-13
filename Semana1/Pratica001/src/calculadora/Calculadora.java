package calculadora;

import java.util.Scanner;

public class Calculadora {
	public static void main(String[] args) {
		int op = 0;
		Scanner scanner = new Scanner(System.in);
		System.out.println("Digite o primeiro número:");
		float num1 = scanner.nextFloat();
		System.out.println("Digite o segundo número:");
		float num2 = scanner.nextFloat();
		
		System.out.println("------- Menu -------");
		System.out.println("1. Adição");
        System.out.println("2. Subtração");
        System.out.println("3. Multiplicação");
        System.out.println("4. Divisão");
        System.out.println("-------------------");
		
		do {
        	System.out.println("Qual operação vai ser feita?");        
            op = scanner.nextInt();
        } while (op < 1 || op > 4);
		
		switch(op) {
	    	case 1:
	    		System.out.println(num1 + " + " + num2 + " = " + soma(num1, num2));
	    		break;
	    	case 2:
	    		System.out.println(num1 + " - " + num2 + " = " + subtracao(num1, num2));
	    		break;
	    	case 3:
	    		System.out.println(num1 + " * " + num2 + " = " + multiplicacao(num1, num2));
	    		break;
	    	case 4:
	    		System.out.println(num1 + " / " + num2 + " = " + divisao(num1, num2));
	    		break;
	    	default:
	    		System.out.println("Opção Inválida!");
	    }
		
		scanner.close();
	}
	
	public static float soma(float num1, float num2) {		
		return (num1 + num2);
	}
	
	public static float subtracao(float num1, float num2) {
		return (num1 - num2);
	}
	
	public static float multiplicacao(float num1, float num2) {
		return (num1 * num2);
	}
	
	public static float divisao(float num1, float num2) {
		return (num1 / num2);
	}
}
