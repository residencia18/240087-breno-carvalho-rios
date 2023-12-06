package app;

import cliente.Cliente;

import java.util.ArrayList;
import java.util.Scanner;

public class ControleClientes {
    Scanner scan = new Scanner(System.in);
    ArrayList<Cliente> clientes;

    public ControleClientes() {
        clientes = new ArrayList<Cliente>();
    }

    public void insereCliente() {
        System.out.println("Digite o cpf do cliente (apenas numeros): ");
        String cpf = scan.nextLine();

        if(this.buscaCliente(cpf) != null){
            System.out.println("O CPF deve ser único!");
            return;
        }

        System.out.println("Digite o nome do cliente: ");
        String nome = scan.nextLine();

        try {
            Cliente cliente = new Cliente(cpf, nome);
            this.clientes.add(cliente);
            System.out.println("Cliente adicionado com sucesso!");
        } catch(Exception e) {
            System.out.println(e.getMessage());
        }
    }
    public void consultaCliente(){
        Cliente cliente = buscaCliente();

        if(cliente == null) {
            System.out.println("Cliente não encontrado!");
            return;
        }
        System.out.println(cliente.toString());
    }
    public void listaClientes() {
        for (Cliente cliente: this.clientes) {
            System.out.println(cliente.toString());
            System.out.println();
        }
    }
    public void editaCliente(){
        Cliente cliente = buscaCliente();
        if(cliente == null) {
            System.out.println("Cliente não encontrado!");
            return;
        }

        System.out.println("Digite o novo cpf do cliente (apenas numeros): ");
        String cpf = this.scan.nextLine();
        try {
            cliente.setCpf(cpf);
            System.out.println("CPF alterado com sucesso!");
        } catch(Exception e) {
            System.out.println(e.getMessage());
        }

        System.out.println("Digite o novo nome do cliente: ");
        String nome = this.scan.nextLine();
        try {
            cliente.setNome(nome);
            System.out.println("Nome alterado com sucesso!");
        } catch(Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public void excluiCliente() {
        Cliente cliente = buscaCliente();
        if(cliente == null) {
            System.out.println("Cliente não encontrado!");
            return;
        }
        this.clientes.remove(cliente);
        System.out.println("Cliente excluído com sucesso!");
    }
    public Cliente buscaCliente(String cpf){
        for (Cliente cliente: this.clientes) {
            if(cliente.getCpf().equals(cpf)) {
                return cliente;
            }
        }

        return null;
    }
    public Cliente buscaCliente(){
        System.out.println("Digite o cpf do cliente (apenas numeros): ");
        String cpf = this.scan.nextLine();

        for (Cliente cliente: this.clientes) {
            if(cliente.getCpf().equals(cpf)) {
                return cliente;
            }
        }

        return null;
    }
}
