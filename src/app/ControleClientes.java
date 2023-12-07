package app;

import cliente.Cliente;

import java.util.ArrayList;
import java.util.Scanner;

public class ControleClientes {
    private static Scanner scan = new Scanner(System.in);
    private static ArrayList<Cliente> clientes = new ArrayList<Cliente>();

    public ControleClientes() {
        try{
            clientes.add(new Cliente("08867581570", "Breno"));
        } catch (Exception e) {
            return;
        }
    }

    public static void insereCliente() {
        System.out.println("Digite o cpf do cliente (apenas numeros): ");
        String cpf = scan.nextLine();

        if(buscaCliente(cpf) != null){
            System.out.println("O CPF deve ser único!");
            return;
        }

        System.out.println("Digite o nome do cliente: ");
        String nome = scan.nextLine();

        try {
            Cliente cliente = new Cliente(cpf, nome);
            clientes.add(cliente);
            System.out.println("Cliente adicionado com sucesso!");
        } catch(Exception e) {
            System.out.println(e.getMessage());
        }
    }
    public static void consultaCliente(){
        Cliente cliente = buscaCliente();

        if(cliente == null) {
            System.out.println("Cliente não encontrado!");
            return;
        }
        System.out.println(cliente.toString());
    }
    public static void listaClientes() {
        for (Cliente cliente: clientes) {
            System.out.println(cliente.toString());
            System.out.println();
        }
    }
    public static void editaCliente(){
        Cliente cliente = buscaCliente();
        if(cliente == null) {
            System.out.println("Cliente não encontrado!");
            return;
        }

        System.out.println("Digite o novo cpf do cliente (apenas numeros): ");
        String cpf = scan.nextLine();
        if(buscaCliente(cpf) != null && !cpf.equals(cliente.getCpf())) {
            System.out.println("O CPF deve ser único!");
            return;
        }

        try {
            cliente.setCpf(cpf);
            System.out.println("CPF alterado com sucesso!");
        } catch(Exception e) {
            System.out.println(e.getMessage());
        }

        System.out.println("Digite o novo nome do cliente: ");
        String nome = scan.nextLine();
        try {
            cliente.setNome(nome);
            System.out.println("Nome alterado com sucesso!");
        } catch(Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public static void excluiCliente() {
        Cliente cliente = buscaCliente();
        if(cliente == null) {
            System.out.println("Cliente não encontrado!");
            return;
        }
        clientes.remove(cliente);
        System.out.println("Cliente excluído com sucesso!");
    }
    public static Cliente buscaCliente(String cpf){
        for (Cliente cliente: clientes) {
            if(cliente.getCpf().equals(cpf)) {
                return cliente;
            }
        }

        return null;
    }
    public static Cliente buscaCliente(){
        System.out.println("Digite o cpf do cliente (apenas numeros): ");
        String cpf = scan.nextLine();

        for (Cliente cliente: clientes) {
            if(cliente.getCpf().equals(cpf)) {
                return cliente;
            }
        }

        return null;
    }
}
