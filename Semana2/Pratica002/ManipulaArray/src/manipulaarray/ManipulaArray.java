package manipulaarray;

import java.util.Random;
import java.util.Scanner;

public class ManipulaArray {
    public static void main(String[] args) {
        ManipulaArray manipulator = new ManipulaArray();
        System.out.println("Array inserido pelo usuário: ");
        int[] elements = manipulator.readArray();
        manipulator.showArray(elements);
        System.out.println("Soma: " + manipulator.sum(elements));
        System.out.println("Máximo: " + manipulator.max(elements));
        System.out.println("Mínimo: " + manipulator.min(elements));

        System.out.println();

        System.out.println("Array aleatório: ");
        int[] randomElements = manipulator.randomArray();
        manipulator.showArray(randomElements);
        System.out.println("Soma: " + manipulator.sum(randomElements));
        System.out.println("Máximo: " + manipulator.max(randomElements));
        System.out.println("Mínimo: " + manipulator.min(randomElements));
    }

    public int[] readArray(){
        Scanner scan = new Scanner(System.in);

        System.out.println("Quantos números serão? ");
        int nElements = scan.nextInt();
        int[] elements = new int[nElements];

        for(int i = 0; i < nElements; i++){
            System.out.println("Digite o número " + (i + 1) + ": ");
            elements[i] = scan.nextInt();
        }

        return elements;
    }

    public int[] randomArray(){
        Random rand = new Random();
        Scanner scan = new Scanner(System.in);

        System.out.println("Quantos números serão? ");
        int nElements = scan.nextInt();
        int[] elements = new int[nElements];

        for(int i = 0; i < nElements; i++){
            elements[i] = rand.nextInt(Integer.MAX_VALUE);
        }

        return elements;
    }

    public long sum(int[] elements){
        int sum = 0;
        for (int element : elements) {
            sum += element;
        }

        return sum;
    }

    public int max(int[] elements){
        int max = elements[0];

        for (int element : elements){
            if (element > max){
                max = element;
            }
        }

        return max;
    }

    public int min(int[] elements){
        int min = elements[0];

        for (int element : elements){
            if (element < min){
                min = element;
            }
        }

        return min;
    }

    public void showArray(int[] elements){
        for (int element : elements){
            System.out.print(element + " ");
        }
        System.out.println();
    }
}
