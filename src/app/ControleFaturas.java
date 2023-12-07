package app;

import cliente.Imovel;
import financeiro.Fatura;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Scanner;

public class ControleFaturas {
    private static Scanner scan = new Scanner(System.in);
    private static ArrayList<Fatura> faturas = new ArrayList<>();
    public static void insereFatura(){
        Imovel imovel = ControleImoveis.buscaImovel();
        if(imovel == null) {
            System.out.println("Imóvel não encontrado!");
            return;
        }

        LocalDateTime now = LocalDateTime.now();
        double leitura;
        try {
            System.out.println("Digite o valor da leitura: ");
            leitura = Double.parseDouble(scan.nextLine());
        } catch (Exception e) {
            System.out.println("Digite um valor válido!");
            return;
        }

        try {
            if(imovel.getUltimaLeitura() != 0) {
                imovel.setPenultimaLeitura(imovel.getUltimaLeitura());
                imovel.setUltimaLeitura(leitura);
            }
            imovel.setUltimaLeitura(leitura);
        } catch (Exception e){
            System.out.println(e.getMessage());
        }

        Fatura fatura = new Fatura(now, imovel.getUltimaLeitura(), imovel.getPenultimaLeitura(), (leitura * 10), imovel);
        faturas.add(fatura);
    }

    public static void listaFaturas() {
        for (Fatura fatura: faturas) {
            System.out.println("===== Fatura =====");
            System.out.println(fatura);
        }
    }

    public static void listaFaturas(boolean isQuitada) {
        for (Fatura fatura: faturas) {
            if(fatura.isQuitado() == isQuitada) {
                System.out.println("===== Fatura =====");
                System.out.println(fatura);
            }
        }
    }

    public static void quitaFatura() {
        Fatura fatura = buscaFatura();
        if(fatura == null) {
            System.out.println("Nenhuma fatura encontrada!");
            return;
        }

        fatura.setQuitado(true);
    }

    public static Fatura buscaFatura(String matricula){
        for (Fatura fatura: faturas) {
            if(fatura.getImovel().getMatricula().equals(matricula)) {
                return fatura;
            }
        }

        return null;
    }
    public static Fatura buscaFatura(){
        System.out.println("Digite a matricula do imovel: ");
        String matricula = scan.nextLine();

        for (Fatura fatura: faturas) {
            if(fatura.getImovel().getMatricula().equals(matricula)) {
                return fatura;
            }
        }

        return null;
    }
}
