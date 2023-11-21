package pontoflutuante;

public class PontoFlutuante {
	public static void main(String[] args) {
		float x, y;
		double a, b;
		
		x = 2;
		do {
			y = x;
			x = x / 2;
		} while(x > 0);
		System.out.println("Float: " + y);
		
		a = 2;
		do {
			b = a;
			a = a / 2;
		} while(a > 0);
		
		System.out.println("Double: " + b);
	}
}
