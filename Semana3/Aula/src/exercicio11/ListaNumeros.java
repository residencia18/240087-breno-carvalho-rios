package exercicio11;

import java.util.ArrayList;
import java.util.Collections;

public class ListaNumeros {
	ArrayList<Float> numeros;
	
	public static void main(String[] args) {
		ListaNumeros lista = new ListaNumeros();
		
		float n1 = 1.5F;
		float n2 = 12.7F;
		float n3 = 2.1F;
		float n4 = 3.0F;

		lista.novoNumero(n1);
		lista.novoNumero(n2);
		lista.novoNumero(n3);
		lista.novoNumero(n4);
		
		lista.listaNumeros();
		
		System.out.println("Média: " + lista.media());
		
		lista.ordena();
		lista.listaNumeros();
		
		lista.mediana();
		lista.colocadoEm(2);
	}
	
	ListaNumeros(){
		this.numeros = new ArrayList<Float>();
	}
	
	void novoNumero(float f) {
		this.numeros.add(f);
	}
	
	void listaNumeros() {
		System.out.println("Lista de números:");
		for(float num : this.numeros) {
			System.out.println(num);
		}
	}
	
	float media() {
		float soma = 0;
		for(float num : this.numeros) {
			soma += num;
		}
		
		return soma / this.numeros.size();
	}
	
	void ordena() {
		this.numeros.sort(null);
	}
	
	void mediana() {
		int index = (int)Math.floor((this.numeros.size() + 1) / 2) - 1;
		System.out.println("Mediana: índice " + index + " | Valor: " + this.numeros.get(index));
	}
	
	void colocadoEm(int n) {
		System.out.println(this.numeros.get(n - 1));
	}
}
