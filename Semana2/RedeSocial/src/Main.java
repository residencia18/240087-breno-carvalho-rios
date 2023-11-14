import cliente.Usuario;
import java.util.Scanner;
import java.util.Random;

public class Main {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		Usuario usuario;
		
		System.out.println("Digite o nome do usuário:");
		String nome = scan.nextLine();
		
		System.out.println("Digite o email do usuário:");
		String email = scan.nextLine();
		
		System.out.println("Digite a nacionalidade do usuário:");
		String nacionalidade = scan.nextLine();
		
		usuario = new Usuario(nome, email, nacionalidade);
		
		String op;
		String postagem;
		while(true) {
			System.out.println("Deseja adicionar uma postagem? (s/n)");
			op = scan.nextLine();
			
			if(op.equalsIgnoreCase("n")) {
				break;
			}
			
			if(!op.equalsIgnoreCase("s") && !op.equalsIgnoreCase("n")) {
				System.out.println("Opção Inválida!");
				continue;
			}
			
			System.out.println("Qual é a postagem?");
			postagem = scan.nextLine();
			usuario.adicionaPostagem(postagem);
			Random rand = new Random();
			usuario.alteraPontuacao(rand.nextInt(10));
		}
		
		System.out.println(usuario.toString());
		System.out.println("Postagens: ");
		usuario.listaPostagens();
		
		scan.close();
	}
}
