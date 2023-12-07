package falhas;

import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

public class Reparo {
    private String descricao;
    private LocalDate previsao;
    private LocalDate dataInicio;
    private LocalDate dataFim;
    private boolean resolvido;

    public Reparo(String descricao, LocalDate previsao) {
        this.descricao = descricao;
        this.previsao = previsao;
        this.resolvido = false;
    }


    public String getDescricao() {
        return descricao;
    }

    public LocalDate getPrevisao() {
        return previsao;
    }

    public LocalDate getDataInicio() {
        return dataInicio;
    }

    public LocalDate getDataFim() {
        return dataFim;
    }

    public boolean isResolvido() {
        return resolvido;
    }

    public void imprimirDetalhesReparo() {
        System.out.println("Descrição: " + this.getDescricao());
        System.out.println("Previsão: " + this.getPrevisao());
        System.out.println("Data Início: " + this.getDataInicio());
        System.out.println("Data Fim: " + this.getDataFim());
        System.out.println("Resolvido: " + (this.isResolvido() ? "Sim" : "Não"));
        System.out.println("----------------------");
    }

    public void iniciarReparo() {
        if (dataInicio == null) {
            setDataInicio();
            System.out.println("Reparo iniciado com sucesso.");
        } else {
            System.out.println("O reparo já foi iniciado anteriormente.");
        }
    }

    private void setDataInicio() {
        this.dataInicio = LocalDate.now();
    }

    public void setDataFim(LocalDate dataFim) {
        this.dataFim = dataFim;
    }

    public void setResolvido(boolean resolvido) {
        this.resolvido = resolvido;
    }
}

