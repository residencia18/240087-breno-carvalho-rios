package usuario;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Scanner;

public class Sessao {
    Usuario usuarioConectado;
    ArrayList<Amizade> listaAmizades;
    ControleUsuarios controleUsuarios;
    LocalDateTime dataHoraInicio;
    LocalDateTime dataHoraFim;

    public Sessao(Usuario usuario){
        listaAmizades = new ArrayList<Amizade>();
        controleUsuarios = new ControleUsuarios();
        dataHoraInicio = LocalDateTime.now();
        this.usuarioConectado = usuario;
    }

    public void logar(){}
    public void Deslogar(){}
    public void solicitaAutenticacao(){}
    public void criarAmizade(){}
    public void desfazerAmizade(){}
    public void criarPostagem(){}
    public void listarPostagens(){}

    public void run(){
        Scanner scan = new Scanner(System.in);

        while (true) {
            System.out.println("-----Menu-----");
            System.out.println("1. Criar postagem");
            System.out.println("2. Listar postagens");
            System.out.println("3. Criar amizade");
            System.out.println("4. Desfazer amizade");
            System.out.println("0. Sair");

            int op = scan.nextInt();

            switch(op){
                case 1:
                    this.criaPostagem();
                    break;
                case 2:
                    this.listaPostagens();
                    break;
                case 3:
                    break;
                case 0:
                    dataHoraFim = LocalDateTime.now();
                    break;
                default:
                    System.out.println("Opção Inválida");
                    break;
            }

            if(op == 0){
                break;
            }
        }
    }

    public void criaPostagem(){
        Scanner scan = new Scanner(System.in);
        String postagem = scan.nextLine();

        this.usuarioConectado.novaPostagem(postagem);
    }

    public void listaPostagens(){
        this.usuarioConectado.listaPostagens();
    }
}
