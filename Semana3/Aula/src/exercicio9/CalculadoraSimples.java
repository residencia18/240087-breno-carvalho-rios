package exercicio9;

import java.util.Scanner;

public class CalculadoraSimples {
	public static void main(String[] args) {
		char op;
		Scanner scanner = new Scanner(System.in);
		System.out.println("Digite o primeiro número:");
		float num1 = scanner.nextFloat();
		System.out.println("Digite o segundo número:");
		float num2 = scanner.nextFloat();
		
		scanner.nextLine();
		
		System.out.println("------- Menu -------");
		System.out.println("A. Adição");
        System.out.println("S. Subtração");
        System.out.println("M. Multiplicação");
        System.out.println("D. Divisão");
        System.out.println("-------------------");
		
		do {
        	System.out.println("Qual operação vai ser feita?");        
            op = scanner.nextLine().charAt(0);
        } while (op != 'A' && op != 'S' && op != 'M' && op != 'D');
		
		switch(op) {
	    	case 'A':
	    		System.out.println(num1 + " + " + num2 + " = " + soma(num1, num2));
	    		break;
	    	case 'S':
	    		System.out.println(num1 + " - " + num2 + " = " + subtracao(num1, num2));
	    		break;
	    	case 'M':
	    		System.out.println(num1 + " * " + num2 + " = " + multiplicacao(num1, num2));
	    		break;
	    	case 'D':
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
