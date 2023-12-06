package cliente;

public class Cliente {
    private String cpf, nome;

    public Cliente(String cpf, String nome) throws Exception {
        this.setCpf(cpf);
        this.setNome(nome);
    }

    public String toString() {
        return String.format("Cpf: %s \nNome: %s", this.cpf, this.nome);
    }

    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) throws Exception {
        if(cpf.length() != 11 || !cpf.matches("[0-9]+")) {
            throw new Exception("CPF Inválido");
        }
        this.cpf = cpf;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) throws Exception {
        if(nome.isBlank()) {
            throw new Exception("O nome não pode estar vazio");
        }
        this.nome = nome;
    }
}
