package app;

import financeiro.Fatura;
import financeiro.Pagamento;

import java.util.ArrayList;
import java.util.List;

public class ControlePagamentos {

    private List<Pagamento> pagamentos;

    public ControlePagamentos() {
        this.pagamentos = new ArrayList<>();
    }

    public void incluirPagamento(Pagamento pagamento) {
        this.pagamentos.add(pagamento);
    }

    public List<Pagamento> listarPagamentos() {
        return this.pagamentos;
    }

    public List<Pagamento> listarPagamentosPorFatura(Fatura fatura) {
        List<Pagamento> pagamentosPorFatura = new ArrayList<>();
        for (Pagamento pagamento : pagamentos) {
            if (pagamento.getFatura().equals(fatura)) {
                pagamentosPorFatura.add(pagamento);
            }
        }
        return pagamentosPorFatura;
    }

}
