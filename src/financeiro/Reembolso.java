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
}
