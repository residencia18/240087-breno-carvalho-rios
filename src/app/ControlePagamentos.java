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

    private static ArrayList<Pagamento> pagamentos  = new ArrayList<>();
    private static Scanner scanner  = new Scanner(System.in);

    public ControlePagamentos() {
    }

    public static void incluirPagamento() {
        System.out.println("\n### Incluir Pagamento ###");

        System.out.print("Digite a matrícula do imóvel: ");
        String matriculaImovel = scanner.nextLine();

        Fatura fatura = ControleFaturas.buscaFatura(matriculaImovel);

        if (fatura == null) {
            System.out.println("Nenhuma fatura encontrada para a matrícula do imóvel fornecida.");
            return;
        }

        if (fatura.isQuitado()) {
            System.out.println("Não existe nenhuma fatura em aberto.");
            return;
        }

        // Solicite o valor do pagamento
        System.out.print("Digite o valor do pagamento: ");
        double valorPagamento = scanner.nextDouble();
        scanner.nextLine(); // Limpar o buffer do scanner

        LocalDateTime dataPagamento = LocalDateTime.now();

        // Crie uma instância de Pagamento usando a fatura, valor e data fornecidos
        Pagamento pagamento = new Pagamento(fatura, valorPagamento, dataPagamento);

        // Adicione o pagamento à lista de pagamentos
        adicionarPagamento(pagamento);
        System.out.println("Pagamento registrado com sucesso!");

        ArrayList<Pagamento> pagamentosPorFatura = buscarPagamentosPorFatura(fatura);
        double somaPagamentos = pagamentosPorFatura.stream().mapToDouble(Pagamento::getValor).sum();

        if (somaPagamentos >= fatura.getValor()) {
            double valorReembolso = somaPagamentos - fatura.getValor();
            if (valorReembolso > 0) {
                Reembolso reembolso = new Reembolso(pagamento, valorReembolso, dataPagamento);
                pagamento.setReembolso(reembolso);
                System.out.println("Reembolso gerado: ");
                System.out.println(reembolso.toString());
            }
            fatura.setQuitado(true);
        }
    }

    private static void adicionarPagamento(Pagamento pagamento) {
        pagamentos.add(pagamento);
    }

    public static void listarTodosPagamentos() {
        System.out.println("\n### Listar Todos os Pagamentos ###");
        for (Pagamento pagamento : pagamentos) {
            System.out.println(pagamento);
        }
    }

    public static ArrayList<Pagamento> buscarPagamentosPorFatura(Fatura fatura) {
        ArrayList<Pagamento> pagamentosPorFatura = new ArrayList<>();
        for (Pagamento pagamento : pagamentos) {
            if (pagamento.getFatura().equals(fatura)) {
                pagamentosPorFatura.add(pagamento);
            }
        }
        return pagamentosPorFatura;
    }

    public static void mostrarPagamentosPorFatura() {
        Fatura fatura = ControleFaturas.buscaFatura();
        if(fatura == null) {
            System.out.println("Nenuhma fatura encontrada!");
        }

        List<Pagamento> pagamentosPorFatura = buscarPagamentosPorFatura(fatura);
        for (Pagamento pagamento : pagamentosPorFatura) {
            System.out.println(pagamento);
        }
    }

    public static void mostrarTodosReembolsos() {
        for (Pagamento pagamento: pagamentos) {
            if(pagamento.getReembolso() != null) {
                System.out.println(pagamento.getReembolso());
            }
        }
    }
}
