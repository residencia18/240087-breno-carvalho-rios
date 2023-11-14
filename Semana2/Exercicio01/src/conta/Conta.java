package conta;

public class Conta {
	int numero;
	String nome;
	double saldo;
	
	public Conta(int numero, String nome) {
		this.setNumero(numero);
		this.setNome(nome);
		this.setSaldo(0.0);
	}
	
	public int getNumero() {
		return numero;
	}

	public void setNumero(int numero) {
		this.numero = numero;
	}

	public String getNome() {
		return nome;
	}

	public void setNome(String nome) {
		this.nome = nome;
	}

	public double getSaldo() {
		return saldo;
	}

	public void setSaldo(double saldo) {
		this.saldo = saldo;
	}

	public void deposita(double valor) {
		this.saldo = saldo + valor;
	}
	
	public void consulta() {
		System.out.println("Cliente: " + this.nome);
		System.out.println("Saldo Atual: R$ " + this.saldo);
		System.out.println("Número da Conta: " + this.numero);
	}
	
	public boolean saque(double valor) {
		if (this.saldo < valor) {
			return false;
		}
		
		this.saldo -= valor;
		return true;
	}
}
