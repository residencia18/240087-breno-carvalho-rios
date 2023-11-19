package cliente;

import java.util.ArrayList;

public class Usuario {
	private String nome, email, nacionalidade;
	private int quantidadeDePostagens, pontuacao;
	private ArrayList<String> postagens;

	public Usuario(String nome, String email, String nacionalidade){
		setNome(nome);
		setEmail(email);
		setNacionalidade(nacionalidade);
		this.postagens = new ArrayList<String>();
		this.quantidadeDePostagens = 0;
		this.pontuacao = 0;
	}
	
	public void adicionaPostagem(String post) {
		if(post.isBlank()) {
			return;
		}
		
		this.postagens.add(post);
		this.incrementaQuantidadeDePostagens();
	}
	
	public void listaPostagens() {
		int index = 1;
		for(String post : this.postagens) {
			System.out.println(index + ". " + post);
			index++;
		}
	}
	
	private void incrementaQuantidadeDePostagens() {
		this.quantidadeDePostagens++;
	}
	
	public void alteraPontuacao(int delta) {
		this.pontuacao += delta;
		
		if(this.pontuacao < 0) {
			this.pontuacao = 0;
		}
	}
	
	public String toString() {
		return "Nome: " + this.nome + "\n" +
				"Email: " + this.email+ "\n" +
				"Nacionalidade: " + this.nacionalidade + "\n" +
				"Postagens: " + this.quantidadeDePostagens + "\n" +
				"Pontos: " + this.pontuacao + "\n";
	}
	
	public String getNome() {
		return nome;
	}

	public void setNome(String nome) {
		this.nome = nome;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getNacionalidade() {
		return nacionalidade;
	}

	public void setNacionalidade(String nacionalidade) {
		this.nacionalidade = nacionalidade;
	}

	public int getQuantidadeDePostagens() {
		return quantidadeDePostagens;
	}

	public int getPontuacao() {
		return pontuacao;
	}
}
