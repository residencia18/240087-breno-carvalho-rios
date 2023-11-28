package usuario;

import java.util.ArrayList;
import java.util.Scanner;

public class ControleSessoes {
    ArrayList<Sessao> listaSessoes;
    ControleUsuarios controleUsuarios;

    public ControleSessoes(){
        this.listaSessoes = new ArrayList<Sessao>();
        this.controleUsuarios = new ControleUsuarios();
    }

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        ControleSessoes app = new ControleSessoes();

        while (true) {
            System.out.println("-----Menu-----");
            System.out.println("1. Novo usuário");
            System.out.println("2. Remove usuário");
            System.out.println("3. Logar");
            System.out.println("0. Sair");

            int op = scan.nextInt();

            switch(op){
                case 1:
                    app.controleUsuarios.criaUsuario();
                    break;
                case 2:
                    app.removeUsuario();
                    break;
                case 3:
                    app.login();
                    break;
                case 0:
                    break;
                case 5:
                    app.listaSessoes();
                    break;
                default:
                    System.out.println("Opção Inválida");
                    break;
            }

            if(op == 0){
                return;
            }
        }
    }

    public Usuario buscaUsuario() {
        Scanner scan = new Scanner(System.in);

        System.out.println("Email: ");
        String email = scan.nextLine();
        System.out.println("Senha: ");
        String senha = scan.nextLine();

        return this.controleUsuarios.autenticaUsuario(email, senha);
    }

    public void login(){
        Usuario usuario = this.buscaUsuario();
        if(usuario == null){
            System.out.println("Usuário Inválido");
            return;
        }

        Sessao sessao = Usuario.logar(usuario);

        this.listaSessoes.add(sessao);
        sessao.run();
    }

    public boolean removeUsuario(){
        Usuario usuario = this.buscaUsuario();
        if(usuario == null){
            System.out.println("Usuário Inválido");
            return false;
        }

        this.controleUsuarios.removeUsuario(usuario);
        return true;
    }

    public void listaSessoes(){
        for(Sessao sessao : listaSessoes){
            System.out.println(sessao.usuarioConectado.getNome());
            System.out.println(sessao.dataHoraInicio);
            System.out.println(sessao.dataHoraFim);
            System.out.println();
        }
    }
}
