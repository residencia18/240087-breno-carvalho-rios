package exercicio12;

public class CalculosEstatisticos {
	public static void main(String[] args) {
		CalculosEstatisticos calc = new CalculosEstatisticos();
		
		System.out.println(calc.fatorial(8));
		System.out.println(calc.arranjo(8, 4));
		System.out.println(calc.combinacao(6, 2));
	}
	
	public long fatorial(int n) {
		long fat = 1;
		for(int i = 1; i <= n; i++) {
			fat *= i;
		}
		
		return fat;
	}
	
	public long arranjo(int n, int p) {
		return (this.fatorial(n) / (this.fatorial(n - p)));
	}
	
	public long combinacao(int n, int p) {
		return this.fatorial(n) / (this.fatorial(p) * this.fatorial(n - p));
	}
}
