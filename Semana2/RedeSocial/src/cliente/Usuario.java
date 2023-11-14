package cliente;

import java.util.ArrayList;

public class Usuario {
	private String nome, email, nacionalidade;
	private ArrayList<String> postagens;

	public Usuario(String nome, String email, String nacionalidade){
		setNome(nome);
		setEmail(email);
		setNacionalidade(nacionalidade);
		this.postagens = new ArrayList<String>();
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
}
