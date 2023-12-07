package app;

import financeiro.Fatura;
import financeiro.Pagamento;
import financeiro.Reembolso;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ControlePagamentos {

    private List<Pagamento> pagamentos;
    private Scanner scanner;
    private ControleFaturas controleFaturas; 

    public ControlePagamentos(ControleFaturas controleFaturas) {
        this.pagamentos = new ArrayList<>();
        this.scanner = new Scanner(System.in);
        this.controleFaturas = controleFaturas; 
    }

    public void incluirPagamento() {
        System.out.println("\n### Incluir Pagamento ###");
        System.out.print("Digite a matrícula do imóvel: ");
        String matriculaImovel = scanner.nextLine();


        Fatura fatura = ControleFaturas.buscaFatura(matriculaImovel);

        if (fatura == null) {
            System.out.println("Nenhuma fatura encontrada para a matrícula do imóvel fornecida.");
            return;
        }

        // Solicite o valor do pagamento
        System.out.print("Digite o valor do pagamento: ");
        double valorPagamento = scanner.nextDouble();
        scanner.nextLine(); // Limpar o buffer do scanner

        // Solicite a data do pagamento (assumindo que o formato é String para simplificar)
        System.out.print("Digite a data do pagamento (formato YYYY-MM-DD HH:mm:ss): ");
        String dataPagamentoStr = scanner.nextLine();
        LocalDateTime dataPagamento = LocalDateTime.parse(dataPagamentoStr, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));

        // Crie uma instância de Pagamento usando a fatura, valor e data fornecidos
        Pagamento pagamento = new Pagamento(fatura, valorPagamento, dataPagamento);

        // Adicione o pagamento à lista de pagamentos
        adicionarPagamento(pagamento);

        // Verifique se o pagamento gera reembolso
        List<Reembolso> reembolsos = pagamento.listarReembolsos();
        if (!reembolsos.isEmpty()) {
            System.out.println("Reembolsos gerados:");
            for (Reembolso reembolso : reembolsos) {
                System.out.println(reembolso);
            }
        }

        System.out.println("Pagamento registrado com sucesso!");
    }

    private void adicionarPagamento(Pagamento pagamento) {
        pagamentos.add(pagamento);
    }

    public void listarTodosPagamentos() {
        System.out.println("\n### Listar Todos os Pagamentos ###");
        for (Pagamento pagamento : pagamentos) {
            System.out.println(pagamento);
        }
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
