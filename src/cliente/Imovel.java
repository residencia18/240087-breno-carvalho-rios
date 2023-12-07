package cliente;

import java.time.LocalDateTime;

public class Imovel {
    String matricula, endereco;
    double ultimaLeitura;
    double penultimaLeitura;
    Cliente proprietario;

    public Imovel(String matricula, String endereco, Cliente proprietario) {
        this.matricula = matricula;
        this.endereco = endereco;
        this.proprietario = proprietario;
        this.penultimaLeitura = 0;
        this.ultimaLeitura = 0;
    }

    public String getMatricula() {
        return matricula;
    }

    public void setMatricula(String matricula) throws Exception {
        if(matricula.isBlank()) {
            throw new Exception("A matricula não pode estar vazia");
        }
        this.matricula = matricula;
    }

    public String getEndereco() {
        return endereco;
    }

    public void setEndereco(String endereco) throws Exception {
        if(endereco.isBlank()) {
            throw new Exception("O endereco não pode estar vazio");
        }
        this.endereco = endereco;
    }

    public double getUltimaLeitura() {
        return ultimaLeitura;
    }

    public void setUltimaLeitura(double ultimaLeitura) throws Exception {
        if(ultimaLeitura == 0) {
            throw new Exception("A ultima leitura não pode ser 0!");
        }
        this.ultimaLeitura = ultimaLeitura;
    }


    public double getPenultimaLeitura() {
        return penultimaLeitura;
    }

    public void setPenultimaLeitura(double penultimaLeitura) throws Exception {
        if(penultimaLeitura == 0) {
            throw new Exception("A penultima leitura não pode ser 0!");
        }
        this.penultimaLeitura = penultimaLeitura;
    }


    public Cliente getProprietario() {
        return proprietario;
    }

    public void setProprietario(Cliente proprietario) throws Exception {
        if(proprietario == null) {
            throw new Exception("O proprietario não pode estar vazio");
        }
        this.proprietario = proprietario;
    }
    
    public String toString() {
        return String.format(
                "Matricula: %s \nEndereco: %s \nUltima Leitura: %s KW\nPenultima Leitura: %s KW\nProprietario: %s",
                this.matricula, this.endereco, this.ultimaLeitura, this.penultimaLeitura, this.proprietario.getNome()
        );
    }

}
