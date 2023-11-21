package exercicio13;

public class GeradorPrimos {
	public static void main(String[] args) {
		GeradorPrimos.divisoresN(15);
		GeradorPrimos.ePrimo(3);
		GeradorPrimos.primosMenoresQueN(50);
		GeradorPrimos.nPrimeirosPrimos(10);
	}
	
	public static void divisoresN(int n) {
		System.out.println("Divisores de " + n + ": ");
		for(int i = 1; i <= n; i++) {
			if(n % i == 0) {
				System.out.println(i);
			}
		}
	}
	
	private static int qtdDivisoresN(int n) {
		int quantidadade = 0;
		for(int i = 1; i <= n; i++) {
			if(n % i == 0) {
				quantidadade++;
			}
		}
		
		return quantidadade;
	}
	
	public static void ePrimo(int n) {
		System.out.println(n + (qtdDivisoresN(n) == 2 ? " é " : " não é ") + "primo");
	}
	
	public static void primosMenoresQueN(int n) {
		System.out.println("Primos menores que " + n + ": ");
		for(int i = 1; i <= n; i++) {
			if(qtdDivisoresN(i) == 2) {
				System.out.println(i);
			}
		}
	}
	

	public static void nPrimeirosPrimos(int n) {
		int i = 0;
		System.out.println(n + " primeiros números primos: ");
		while(n > 0) {
			if(qtdDivisoresN(i) == 2) {
				System.out.println(i);
				n--;
			}
			i++;
		}
	}
}
