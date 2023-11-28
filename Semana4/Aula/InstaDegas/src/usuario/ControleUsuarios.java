package usuario;

import java.util.ArrayList;
import java.util.Scanner;

public class ControleUsuarios {
    private ArrayList<Usuario> listaUsuarios;

    public ControleUsuarios(){
        this.listaUsuarios = new ArrayList<Usuario>();
    }

    public void criaUsuario(){
        Scanner scan = new Scanner(System.in);
        System.out.print("Nome: ");
        String nome = scan.nextLine();

        System.out.print("Senha: ");
        String senha = scan.nextLine();

        System.out.print("Email: ");
        String email = scan.nextLine();

        Usuario usuario = new Usuario(nome, senha, email);

        this.listaUsuarios.add(usuario);
    }

    public boolean removeUsuario(Usuario usuario){
        return this.listaUsuarios.remove(usuario);
    }

    public ArrayList<Usuario> getListaUsuarios() {
        return listaUsuarios;
    }

    public Usuario autenticaUsuario(String email, String senha){
        for (Usuario usuario : this.listaUsuarios){
            if(usuario.getEmail().equals(email) && usuario.getSenha().equals(senha)){
                return usuario;
            }
        }

        return null;
    }
}
