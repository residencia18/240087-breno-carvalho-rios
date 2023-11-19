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

	public boolean deposita(double valor) {
		if (valor < 0) {
			return false;
		}
		
		this.saldo = saldo + valor;
		return true;
	}
	
	public void consulta() {
		System.out.println("Número da Conta: " + this.numero);
		System.out.println("Cliente: " + this.nome);
		System.out.println("Saldo Atual: R$ " + String.format("%.2f", this.saldo));
	}
	
	public boolean saque(double valor) {
		if (this.saldo < valor || valor < 0) {
			return false;
		}
		
		this.saldo -= valor;
		return true;
	}
}
