package conversordemoedas;

import java.util.Scanner;

public class ConversorDeMoedas {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.println("Digite a quantidade que será convertida (em dólares):");
        double value = scan.nextDouble();

        System.out.println("Digite qual é a taxa de conversão:");
        double conversionRate = scan.nextDouble();

        double convertedValue = value * conversionRate;

        System.out.println(value + " USD convertido(s) a uma taxa de 1 para " + conversionRate + " é " + convertedValue);
    }
}