package falhas;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

class Reparo {
    private String descricao;
    private String previsao;
    private String dataInicio;
    private String dataFim;
    private boolean resolvido;

    public Reparo(String descricao, String previsao) {
        this.descricao = descricao;
        this.previsao = previsao;
        this.dataInicio = "";
        this.dataFim = "";
        this.resolvido = false;
    }

    public String getDescricao() {
        return descricao;
    }

    public String getPrevisao() {
        return previsao;
    }

    public String getDataInicio() {
        return dataInicio;
    }

    public String getDataFim() {
        return dataFim;
    }

    public boolean isResolvido() {
        return resolvido;
    }

    public void listarReparos(ArrayList<Reparo> reparos) {
        if (reparos.isEmpty()) {
            System.out.println("Nenhum reparo cadastrado.");
            return;
        }

        System.out.println("Lista de Todos os Reparos:");
        for (Reparo reparo : reparos) {
            imprimirDetalhesReparo(reparo);
        }
    }

    public void listarReparosEmAberto(ArrayList<Reparo> reparos) {
        if (reparos.isEmpty()) {
            System.out.println("Nenhum reparo cadastrado.");
            return;
        }

        System.out.println("Lista de Reparos em Aberto:");
        for (Reparo reparo : reparos) {
            if (!reparo.isResolvido()) {
                imprimirDetalhesReparo(reparo);
            }
        }
    }

    public void encerrarReparo(ArrayList<Reparo> reparos, String descricaoFalhaNaoResolvida) {
        if (reparos.isEmpty()) {
            System.out.println("Nenhum reparo em aberto encontrado para encerrar.");
            return;
        }

        for (Reparo reparo : reparos) {
            if (!reparo.isResolvido()) {
                reparo.setDataFim(getCurrentDate());
                reparo.setResolvido(true);

                // Verifica se a falha foi resolvida
                if (!descricaoFalhaNaoResolvida.isEmpty()) {
                    // Cria um novo reparo para a mesma falha
                    Reparo novoReparo = new Reparo(descricaoFalhaNaoResolvida, getPrevisao());
                    reparos.add(novoReparo);
                    System.out.println("Novo reparo criado para a falha não resolvida: " + descricaoFalhaNaoResolvida);
                }

                System.out.println("Reparo encerrado com sucesso.");
                return;
            }
        }
        System.out.println("Nenhum reparo em aberto encontrado para encerrar.");
    }

    private void imprimirDetalhesReparo(Reparo reparo) {
        System.out.println("Descrição: " + reparo.getDescricao());
        System.out.println("Previsão: " + reparo.getPrevisao());
        System.out.println("Data Início: " + reparo.getDataInicio());
        System.out.println("Data Fim: " + reparo.getDataFim());
        System.out.println("Resolvido: " + (reparo.isResolvido() ? "Sim" : "Não"));
        System.out.println("----------------------");
    }

    private String getCurrentDate() {
        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
        return sdf.format(new Date());
    }

    public void iniciarReparo() {
        if (dataInicio.isEmpty()) {
            setDataInicio();
            System.out.println("Reparo iniciado com sucesso.");
        } else {
            System.out.println("O reparo já foi iniciado anteriormente.");
        }
    }

    private void setDataInicio() {
        this.dataInicio = getCurrentDate();
    }

    private void setDataFim(String dataFim) {
        this.dataFim = dataFim;
    }

    private void setResolvido(boolean resolvido) {
        this.resolvido = resolvido;
    }
}

