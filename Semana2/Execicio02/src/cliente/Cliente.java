package cliente;
import java.util.Scanner;

public class Cliente {
	String nome, cpf;
	int idade;
	
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		String nome, cpf;
		System.out.println("Digite o nome do cliente: ");
		nome = scanner.nextLine();
		System.out.println("Digite o cpf do cliente: ");
		cpf = scanner.nextLine();
		
		Cliente novoCliente = new Cliente(nome, cpf);
		
		System.out.println("Novo Cliente: ");
		System.out.println("Nome: " + novoCliente.getNome());
		System.out.println("CPF: " + novoCliente.getCpf());
		System.out.println("Idade: " + novoCliente.getIdade());
		
		System.out.println("Digite o novo nome (Deixe vazio se não quiser alterar): ");
		nome = scanner.nextLine();
		novoCliente.setNome(nome);
		
		System.out.println("Digite o novo CPF (Deixe vazio se não quiser alterar): ");
		cpf = scanner.nextLine();
		novoCliente.setCpf(cpf);
		
		System.out.println("Digite a nova idade (Deixe vazio se não quiser alterar): ");
		String idadeString = scanner.nextLine();
		int idade = idadeString.isBlank() ? 0 : Integer.parseInt(idadeString);
		novoCliente.setIdade(idade);
		
		System.out.println("Novo Cliente: ");
		System.out.println(novoCliente.toString());
		
		scanner.close();
	}
	
	public Cliente(String nome, String cpf){
		setNome(nome);
		setCpf(cpf);
		this.idade = 0;
	}
	
	public String toString() {
		return "Nome: " + this.nome + "\n" + "CPF: " + this.cpf + "\n" + "Idade: " + this.idade;
	}

	public String getNome() {
		return nome;
	}

	public void setNome(String nome) {
		if(nome.isBlank()) {
			return;
		}
		
		this.nome = nome;
	}

	public String getCpf() {
		return cpf;
	}

	public void setCpf(String cpf) {
		if(cpf.isBlank()) {
			return;
		}
		
		this.cpf = cpf;
	}

	public int getIdade() {
		return idade;
	}

	public void setIdade(int idade) {
		if(idade <= 0) {
			return;
		}
		
		this.idade = idade;
	}
}
