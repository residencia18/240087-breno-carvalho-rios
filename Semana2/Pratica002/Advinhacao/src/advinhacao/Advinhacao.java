package advinhacao;

import java.util.Random;
import java.util.Scanner;

public class Advinhacao {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Random rand = new Random();
        int luckyNumber =  rand.nextInt(100);
        int attempts = 0;
        System.out.println(luckyNumber);

        while(true){
            System.out.println("Digite um número:");
            int number = scan.nextInt();

            if(number == luckyNumber){
                System.out.println("Parabéns! Você acertou o número em " + attempts + " tentativas!");
                break;
            }
            attempts++;

            if(number > (luckyNumber + 10)){
                System.out.println("Passou longe! O número é bem menor do que isso.");
            } else if(number > luckyNumber){
                System.out.println("Quase lá! Mas o número é menor do que isso.");
            }

            if(number < (luckyNumber - 10)){
                System.out.println("Passou longe! O número é bem maior do que isso.");
            } else if(number < luckyNumber){
                System.out.println("Quase lá! Mas o número é maior do que isso.");
            }

            System.out.println(number);
        }
    }
}
