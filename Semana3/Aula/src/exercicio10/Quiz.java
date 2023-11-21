package exercicio10;
import java.util.Scanner;
import java.util.ArrayList;

public class Quiz {
	private ArrayList<Pergunta> perguntas;
	private int pontos;
	
	public static void main(String[] args) {
		Quiz quiz = new Quiz();
		
		while(true) {
			if(!quiz.inserirPergunta()) {
				break;
			}
		}
		
		for(Pergunta pergunta: quiz.perguntas) {
			boolean acertou = pergunta.fazPergunta();
			if(acertou) {
				quiz.setPontos(quiz.getPontos() + 1);
			}
		}
		
		System.out.println("De " + quiz.getPerguntas().size() + " perguntas, você fez " + quiz.pontos + " pontos!");
	}
	
	public Quiz(){
		this.perguntas = new ArrayList<Pergunta>();
		this.pontos = 0;
	}
	
	public boolean inserirPergunta() {
		Scanner scan = new Scanner(System.in);
		
		System.out.println("Digite a pergunta (deixe vazio para encerrar)");
		String titulo = scan.nextLine();
		
		if(titulo.length() < 1) {
			return false;
		}
		
		String[] alternativas = new String[4];
		for(int i = 0; i < 4; i++) {
			System.out.println("Digite a alternativa " + (i + 1) + ": ");
			alternativas[i] = scan.nextLine();
		}
		
		System.out.println("Digite o numero da resposta");
		int resposta = scan.nextInt();
		
		Pergunta pergunta = new Pergunta(titulo, resposta, alternativas);
		this.perguntas.add(pergunta);
		
		return true;
	}

	public ArrayList<Pergunta> getPerguntas() {
		return perguntas;
	}

	public void setPerguntas(ArrayList<Pergunta> perguntas) {
		this.perguntas = perguntas;
	}

	public int getPontos() {
		return pontos;
	}

	public void setPontos(int pontos) {
		this.pontos = pontos;
	}
	
	
}