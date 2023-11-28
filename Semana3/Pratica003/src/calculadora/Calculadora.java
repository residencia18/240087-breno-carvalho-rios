package calculadora;

import java.util.Scanner;

public class Calculadora {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);

		while(true) {
			int op = 0;

			System.out.println("------- Menu -------");
			System.out.println("1. Adição");
			System.out.println("2. Subtração");
			System.out.println("3. Multiplicação");
			System.out.println("4. Divisão");
			System.out.println("0. Sair");
			System.out.println("-------------------");

			do {
				System.out.println("Qual operação vai ser feita?");
				op = scanner.nextInt();
			} while (op < 0 || op > 4);

			if(op == 0) {
				break;
			}

			System.out.println("Digite o primeiro número:");
			float num1 = scanner.nextFloat();
			System.out.println("Digite o segundo número:");
			float num2 = scanner.nextFloat();

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
					try{
						System.out.println(num1 + " / " + num2 + " = " + divisao(num1, num2));
					} catch (ArithmeticException exception) {
						System.out.println(exception.getMessage());
					}
					break;
				default:
					System.out.println("Opção Inválida!");
			}
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
        if(num2 == 0){
            throw new ArithmeticException("Não é possível dividir por 0");
        }
        
		return (num1 / num2);
	}
}
