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
        verificarQuitacaoFatura();
    }

    public void incluirReembolso(double valor) {
        if (valor > this.valor) {
            Reembolso reembolso = new Reembolso(this, valor, LocalDateTime.now());
            this.reembolsos.add(reembolso);
            System.out.println("Reembolso gerado: " + reembolso);
        }
    }

    public List<Reembolso> listarReembolsos() {
        return this.reembolsos;
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

   

    private void verificarQuitacaoFatura() {
        double somaPagamentos = this.reembolsos.stream().mapToDouble(Reembolso::getValor).sum() + this.valor;
        if (somaPagamentos >= this.fatura.getValor()) {
            this.fatura.setQuitado(true);
        }
    }

}
