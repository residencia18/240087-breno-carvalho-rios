package exercicio7;

public class TrocaVariaveisV1 {
	public static void main(String[] args) {
		int var1 = 10;
		int var2 = 50;
		
		System.out.println("Antes da Troca: ");
		System.out.println("Var 1 = " + var1);
		System.out.println("Var 2 = " + var2);

		int aux;
		aux = var1;
		var1 = var2;
		var2 = aux;
		
		System.out.println("Depois da Troca: ");
		System.out.println("Var 1 = " + var1);
		System.out.println("Var 2 = " + var2);
	}
}
