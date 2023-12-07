package app;

import cliente.Imovel;
import falhas.Falha;
import falhas.FalhaDistribuicao;
import falhas.FalhaGeracao;
import falhas.Reparo;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Scanner;

public class ControleFalhas {
    private static Scanner scan = new Scanner(System.in);
    private static ArrayList<FalhaGeracao> falhasGeracao = new ArrayList<>();
    private static ArrayList<FalhaDistribuicao> falhasDistribuicao = new ArrayList<>();

    public static void reportaFalha() {
        Imovel imovel = ControleImoveis.buscaImovel();
        if(imovel == null) {
            System.out.println("Imóvel não encontrado!");
            return;
        }
        System.out.println("Qual o tipo da falha?");
        System.out.println("1. Falha de Geração");
        System.out.println("2. Falha de Distribuição");
        int op;
        try {
            op = Integer.parseInt(scan.nextLine());
        } catch (Exception e) {
            System.out.println("Valor inválido");
            return;
        }
        System.out.println("Digite a descrição da falha:");
        String descricao = scan.nextLine();

        System.out.println("Digite a previsão de solução da falha:");
        LocalDate previsao;
        try {
            previsao = LocalDate.parse(scan.nextLine(), DateTimeFormatter.ofPattern("dd/MM/yyyy"));
        } catch (Exception e) {
            System.out.println("Digite uma data válida!");
            System.out.println(e.getMessage());
            return;
        }

        switch (op) {
            case 1:
                novaFalhaGeracao(descricao, previsao, imovel);
                break;
            case 2:
                novaFalhaDistribuicao(descricao, previsao, imovel);
                break;
            default:
                System.out.println("Opção inválida");
        }
    }

    public static void novaFalhaGeracao(String descricao, LocalDate previsao, Imovel imovel) {
        FalhaGeracao falha = new FalhaGeracao(descricao, previsao, imovel);
        falhasGeracao.add(falha);
    }

    public static void novaFalhaDistribuicao(String descricao, LocalDate previsao, Imovel imovel) {
        System.out.println("Vamos precisar criar um novo reparo: ");
        Reparo reparo = novoReparo();
        if(reparo == null) {
            return;
        }
        FalhaDistribuicao falha = new FalhaDistribuicao(descricao, previsao, imovel);
        falha.getReparos().add(reparo);
        falhasDistribuicao.add(falha);
    }

    public static Reparo novoReparo() {
        System.out.println("Digite a descrição do reparo: ");
        String descricao = scan.nextLine();
        System.out.println("Digite a previsão de realização do reparo:");
        LocalDate previsao;
        try {
            previsao = LocalDate.parse(scan.nextLine(), DateTimeFormatter.ofPattern("dd/MM/yyyy"));
        } catch (Exception e) {
            System.out.println("Digite uma data válida!");
            System.out.println("O reparo não foi criado");
            return null;
        }

        return new Reparo(descricao, previsao);
    }

    public static void listarReparos(boolean resolvido) {
        for (FalhaDistribuicao falha : falhasDistribuicao) {
            if(falha.getReparos().isEmpty()) {
                continue;
            }
            System.out.println("===== " + falha.getDescricao() + " =====");

            for (Reparo reparo : falha.getReparos()) {
                if (reparo.isResolvido() == resolvido) {
                    System.out.println("Reparo: " + reparo.getDescricao());
                    System.out.println("Status: " + reparo.isResolvido());
                }
            }

            System.out.println("-----");
        }
    }

    public static void listarReparos() {
        for (FalhaDistribuicao falha : falhasDistribuicao) {
            if(falha.getReparos().isEmpty()) {
                continue;
            }
            System.out.println("===== " + falha.getDescricao() + " =====");

            for (Reparo reparo : falha.getReparos()) {
                System.out.println("Reparo: " + reparo.getDescricao());
                System.out.println("Status: " + reparo.isResolvido());
            }

            System.out.println("-----");
        }
    }

    public static void encerrarReparo() {
        System.out.println("Digite a descrição da falha: ");
        String descricao = scan.nextLine();
        FalhaDistribuicao falhaDistribuicao = null;

        for (FalhaDistribuicao falha: falhasDistribuicao) {
            if (falha.getDescricao().equalsIgnoreCase(descricao)) {
                falhaDistribuicao = falha;
                break;
            }
        }

        if(falhaDistribuicao == null || falhaDistribuicao.isResolvida()) {
            return;
        }

        for (Reparo reparo : falhaDistribuicao.getReparos()) {
            if (!reparo.isResolvido()) {
                reparo.setDataFim(LocalDate.now());
                reparo.setResolvido(true);
                System.out.println("Reparo encerrado com sucesso.");

                System.out.println("A falha foi resolvida [S/N]?");
                char op = scan.nextLine().charAt(0);

                if(op == 'S' || op == 's') {
                    falhaDistribuicao.setResolvida(true);
                    return;
                }

                Reparo novoReparo;
                do {
                    novoReparo = novoReparo();
                } while (novoReparo == null);

                falhaDistribuicao.getReparos().add(novoReparo);
                System.out.println("Novo reparo criado para a falha não resolvida: " + descricao);

                return;
            }
        }

        System.out.println("Nenhum reparo em aberto encontrado para encerrar.");
    }
}
