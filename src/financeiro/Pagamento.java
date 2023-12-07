package financeiro;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class Pagamento {
     private Fatura fatura;
    private double valor;
    private LocalDateTime data;
    private List<Reembolso> reembolsos;

    public Pagamento(Fatura fatura, double valor, LocalDateTime data) {
        this.fatura = fatura;
        this.valor = valor;
        this.data = data;
        this.reembolsos = new ArrayList<>();
    }

    public void incluirReembolso(Reembolso reembolso) {
        this.reembolsos.add(reembolso);
    }

    public List<Reembolso> listarReembolsos() {
        return this.reembolsos;
    }

}
