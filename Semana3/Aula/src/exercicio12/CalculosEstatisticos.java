package exercicio12;

public class CalculosEstatisticos {
	public static void main(String[] args) {	
		System.out.println(CalculosEstatisticos.fatorial(8));
		System.out.println(CalculosEstatisticos.arranjo(8, 4));
		System.out.println(CalculosEstatisticos.combinacao(6, 2));
	}
	
	public static long fatorial(int n) {
		long fat = 1;
		for(int i = 1; i <= n; i++) {
			fat *= i;
		}
		
		return fat;
	}
	
	public static long arranjo(int n, int p) {
		return (fatorial(n) / (fatorial(n - p)));
	}
	
	public static long combinacao(int n, int p) {
		return fatorial(n) / (fatorial(p) * fatorial(n - p));
	}
}
