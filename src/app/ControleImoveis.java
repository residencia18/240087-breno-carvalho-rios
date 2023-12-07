package app;

import cliente.Imovel;
import cliente.Cliente;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ControleImoveis {

    private static List<Imovel> imoveis  = new ArrayList<>();
    private static Scanner scanner = new Scanner(System.in);

    public static void IncluirImovel() {
        System.out.println("Informe a matricula do imovel: ");
        String matricula = scanner.nextLine();

        if(buscaImovel(matricula) != null){
            System.out.println("A matricula deve ser única!");
            return;
        }

        System.out.println("Informe o endereco do imovel: ");
        String endereco = scanner.nextLine();

        Cliente cliente = ControleClientes.buscaCliente();
        if (cliente == null) {
            System.out.println("Cliente não econtrado!");
            return;
        }

        try {
            Imovel imovel = new Imovel(matricula, endereco, cliente);
            imoveis.add(imovel);
            System.out.println("Imóvel cadastrado com sucesso!");
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return;
        }
    }

    public static void ListarImoveis(){
        for (Imovel imovel : imoveis) {
            System.out.println(imovel);
        }
    }

    public static void ConsultarImovel(){
        Imovel imovel = buscaImovel();
        if(imovel == null) {
            System.out.println("Imóvel não encontrado!");
            return;
        }
        System.out.println(imovel.toString());
    }

    public static void AlterarImovel() {
        Imovel imovel = buscaImovel();

        if(imovel == null) {
            System.out.println("Imóvel não encontrado!");
            return;
        }

        System.out.println("Informe a nova matrícula do imovel: ");
        String novaMatricula = scanner.nextLine();

        if(buscaImovel(novaMatricula) != null && !novaMatricula.equals(imovel.getMatricula())) {
            System.out.println("A matrícula deve ser única!");
            return;
        }

        try {
            imovel.setMatricula(novaMatricula);
            System.out.println("Matrícula alterada comsucesso!");
        } catch(Exception e) {
            System.out.println(e.getMessage());
        }

        System.out.println("Informe o novo endereco do imovel: ");
        String novoEndereco = scanner.nextLine();
        try {
            imovel.setEndereco(novoEndereco);
            System.out.println("Endereço alterado com sucesso!");
        } catch(Exception e) {
            System.out.println(e.getMessage());
        }
    }
    public static void ExcluirImovel() {
        Imovel imovel = buscaImovel();

        if(imovel == null) {
            System.out.println("Imóvel não encontrado!");
            return;
        }

        imoveis.remove(imovel);
        System.out.println("Imóvel excluído com sucesso!");
    }

    public static Imovel buscaImovel(String matricula){
        for (Imovel imovel: imoveis) {
            if(imovel.getMatricula().equals(matricula)) {
                return imovel;
            }
        }

        return null;
    }
    public static Imovel buscaImovel(){
        System.out.println("Digite a matricula do imovel: ");
        String matricula = scanner.nextLine();

        for (Imovel imovel: imoveis) {
            if(imovel.getMatricula().equals(matricula)) {
                return imovel;
            }
        }

        return null;
    }
}
