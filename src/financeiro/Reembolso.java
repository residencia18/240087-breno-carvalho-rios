package financeiro;

import java.time.LocalDateTime;

public class Reembolso {
    private Pagamento pagamento;
    private double valor;
    private LocalDateTime data;

    public Reembolso(Pagamento pagamento, double valor, LocalDateTime data) {
        this.pagamento = pagamento;
        this.valor = valor;
        this.data = data;
    }

  

    public Pagamento getPagamento() {
        return pagamento;
    }

    public void setPagamento(Pagamento pagamento) {
        this.pagamento = pagamento;
    }

    public double getValor() {
        return valor;
    }

    public void setValor(double valor) {
        this.valor = valor;
    }

    public LocalDateTime getData() {
        return data;
    }

    public void setData(LocalDateTime data) {
        this.data = data;
    }


    @Override
    public String toString() {
        return "Valor: R$ " + valor + "\n"
                + "Data: " + data.toLocalDate();
    }
}
