package financeiro;

import cliente.Imovel;

import java.time.LocalDateTime;

public class Fatura {
    private LocalDateTime data;
    private double ultimaLeitura;
    private double penultimaLeitura;
    private double valor;
    private boolean quitado;
    private Imovel imovel;

    public Fatura(LocalDateTime data, double ultimaLeitura, double penultimaLeitura, double valor, Imovel imovel) {
        this.data = data;
        this.ultimaLeitura = ultimaLeitura;
        this.penultimaLeitura = penultimaLeitura;
        this.valor = valor;
        this.quitado = false;
        this.imovel = imovel;
    }

    
    public LocalDateTime getData() {
        return data;
    }

    public void setData(LocalDateTime data) {
        this.data = data;
    }

    public double getUltimaLeitura() {
        return ultimaLeitura;
    }

    public void setUltimaLeitura(double ultimaLeitura) {
        this.ultimaLeitura = ultimaLeitura;
    }

    public double getPenultimaLeitura() {
        return penultimaLeitura;
    }

    public void setPenultimaLeitura(double penultimaLeitura) {
        this.penultimaLeitura = penultimaLeitura;
    }

    public double getValor() {
        return valor;
    }

    public void setValor(double valor) {
        this.valor = valor;
    }

    public boolean isQuitado() {
        return quitado;
    }

    public void setQuitado(boolean quitado) {
        this.quitado = quitado;
    }

    public Imovel getImovel() {
        return imovel;
    }

    public void setImovel(Imovel imovel) {
        this.imovel = imovel;
    }

    // Outros métodos conforme necessário

    @Override
    public String toString() {
        return "Imovel: " + imovel.getMatricula() + "\n"
                + "Data: " + data.toLocalDate() + "\n"
                + "Valor: R$ " + valor + "\n"
                + "UltimaLeitura: " + ultimaLeitura + " KW\n"
                + "PenultimaLeitura: " + penultimaLeitura + " KW\n"
                + "Quitada: " + quitado + "\n";
    }
}
