package exercicio10;

import java.util.Scanner;

public class Pergunta {
	String texto;
	int resposta;
	String[] alternativas;
	
	public Pergunta(String _texto, int _resposta, String[] _alternativas) {
		this.texto = _texto;
		this.resposta = _resposta;
		this.alternativas = _alternativas;
	}
	
	public boolean fazPergunta() {
		Scanner scan = new Scanner(System.in);
		System.out.println(this.texto);
		this.listaAlternativas();
		
		System.out.println("Qual sua escolha?");
		int escolha = scan.nextInt();
		
		if(escolha == this.resposta) {
			System.out.println("Você Acertou!");
			return true;
		}
		
		System.out.println("Você Errou.");
		return false;
	}
	
	public void listaAlternativas() {
		for(int i = 0; i < this.alternativas.length; i++) {
			System.out.println((i + 1) + ". " + alternativas[i]);
		}
	}
}
