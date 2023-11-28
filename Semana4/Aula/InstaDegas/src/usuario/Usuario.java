package usuario;

import java.util.ArrayList;

public class Usuario {
    private static int ID = 0;
    private int id;
    private String nome, senha, email;
    private ArrayList<String> postagens;

    public Usuario(String nome, String senha, String email){
        this.id = ++ID;
        this.nome = nome;
        this.senha = senha;
        this.email = email;
        this.postagens = new ArrayList<String>();
    }

    public void novaPostagem(String postagem){
        this.postagens.add(postagem);
    }

    public void listaPostagens(){
        for(String postagem : this.postagens ) {
            System.out.println(postagem);
        }
    }

    public Amizade criaAmizade(Usuario amigo){
        return new Amizade(this, amigo);
    }

    public static Sessao logar(Usuario usuario){
        return new Sessao(usuario);
    }

    public int getId() {
        return id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
