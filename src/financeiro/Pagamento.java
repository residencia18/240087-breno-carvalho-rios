package financeiro;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class Pagamento {
    private Fatura fatura;
    private double valor;
    private LocalDateTime data;
    private Reembolso reembolso = null;

    public Pagamento(Fatura fatura, double valor, LocalDateTime data) {
        this.fatura = fatura;
        this.valor = valor;
        this.data = data;
    }

    public void setReembolso(Reembolso reembolso) {
        this.reembolso = reembolso;
    }
    public Reembolso getReembolso() {
        return this.reembolso;
    }

    public double getValor() {
        return valor;
    }

    public Fatura getFatura() {
        return fatura;
    }

    public LocalDateTime getData() {
        return data;
    }

    @Override
    public String toString() {
        return "Data da Fatura: " + fatura.getData().toLocalDate() + "\n"
                + "Valor: R$ " + valor + "\n"
                + "Data: " + data.toLocalDate();
    }
}
