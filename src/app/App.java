package app;

import java.util.Scanner;

public class App {
    Scanner scan = new Scanner(System.in);
    ControleClientes controleClientes;
    ControleImoveis controleImoveis;
    ControleFaturas controleFaturas;
    ControlePagamentos controlePagamentos;
    ControleFalhas controleFalhas;

    public App() {
        controleClientes = new ControleClientes();
    }
    public void run() {
        int opcao = -1;
        do{
            System.out.println("========== MENU ==========");
            System.out.println("[1] Gestão de Clientes");
            System.out.println("[2] Gestão de Imóveis");
            System.out.println("[3] Gestão de Faturas");
            System.out.println("[4] Gestão de Pagamentos");
            System.out.println("[5] Gestão de Falhas");
            System.out.println("[0] Sair");

            try {
                opcao = Integer.parseInt(scan.nextLine());
            } catch(NumberFormatException e) {
                System.out.println("Entrada Inválida!");
                continue;
            }

            switch (opcao){
                case 1:
                    this.menuClientes();
                    break;
                case 2:
                    this.menuImoveis();
                    break;
                case 3:
                    this.menuFaturas();
                    break;
                case 4:
                    this.menuPagamentos();
                    break;
                case 5:
                    this.menuFalhas();
                    break;
                case 0:
                    break;
                default:
                    System.out.println("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }
    public void menuClientes() {
        int opcao = -1;
        do{
            System.out.println("===== Gestão de Clientes =====");
            System.out.println("[1] Incluir Cliente");
            System.out.println("[2] Consultar Cliente");
            System.out.println("[3] Listar Clientes");
            System.out.println("[4] Editar Cliente");
            System.out.println("[5] Excluir Cliente");
            System.out.println("[0] Voltar");

            try {
                opcao = Integer.parseInt(scan.nextLine());
            } catch(NumberFormatException e) {
                System.out.println("Entrada Inválida!");
                continue;
            }

            switch (opcao){
                case 1:
                    controleClientes.insereCliente();
                    break;
                case 2:
                    controleClientes.consultaCliente();
                    break;
                case 3:
                    controleClientes.listaClientes();
                    break;
                case 4:
                    controleClientes.editaCliente();
                    break;
                case 5:
                    controleClientes.excluiCliente();
                    break;
                case 0:
                    break;
                default:
                    System.out.println("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }
    public void menuImoveis() {
        int opcao = -1;
        do{
            System.out.println("===== Gestão de Imóveis =====");
            System.out.println("[1] Incluir Imóvel");
            System.out.println("[2] Consultar Imóvel");
            System.out.println("[3] Listar Imóveis");
            System.out.println("[4] Editar Imóvel");
            System.out.println("[5] Excluir Imóvel");
            System.out.println("[0] Voltar");

            try {
                opcao = Integer.parseInt(scan.nextLine());
            } catch(NumberFormatException e) {
                System.out.println("Entrada Inválida!");
                continue;
            }

            switch (opcao){
                case 1:
                    // controleImoveis.algumaCoisa();
                    break;
                case 2:
                    // controleImoveis.algumaCoisa();
                    break;
                case 3:
                    // controleImoveis.algumaCoisa();
                    break;
                case 4:
                    // controleImoveis.algumaCoisa();
                    break;
                case 5:
                    // controleImoveis.algumaCoisa();
                    break;
                case 0:
                    break;
                default:
                    System.out.println("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }
    public void menuFaturas() {
        int opcao = -1;
        do{
            System.out.println("===== Gestão de Faturas =====");
            System.out.println("[1] Incluir Fatura");
            System.out.println("[2] Listar Faturas em Aberto");
            System.out.println("[3] Listar Faturas Pagas");
            System.out.println("[4] Listar Todas as Faturas");
            System.out.println("[0] Voltar");

            try {
                opcao = Integer.parseInt(scan.nextLine());
            } catch(NumberFormatException e) {
                System.out.println("Entrada Inválida!");
                continue;
            }

            switch (opcao){
                case 1:
                    // controleFaturas.algumaCoisa();
                    break;
                case 2:
                    // controleFaturas.algumaCoisa();
                    break;
                case 3:
                    // controleFaturas.algumaCoisa();
                    break;
                case 4:
                    // controleFaturas.algumaCoisa();
                    break;
                case 0:
                    break;
                default:
                    System.out.println("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }
    public void menuPagamentos() {
        int opcao = -1;
        do{
            System.out.println("===== Gestão de Pagamentos =====");
            System.out.println("[1] Fazer um Pagamento");
            System.out.println("[2] Lista de Pagamentos");
            System.out.println("[3] Lista de Reembolsos");
            System.out.println("[0] Voltar");

            try {
                opcao = Integer.parseInt(scan.nextLine());
            } catch(NumberFormatException e) {
                System.out.println("Entrada Inválida!");
                continue;
            }

            switch (opcao){
                case 1:
                    // controlePagamentos.algumaCoisa();
                    break;
                case 2:
                    // controlePagamentos.algumaCoisa();
                    break;
                case 3:
                    // controlePagamentos.algumaCoisa();
                    break;
                case 0:
                    break;
                default:
                    System.out.println("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }
    public void menuFalhas() {
        int opcao = -1;
        do{
            System.out.println("===== Gestão de Falhas =====");
            System.out.println("[1] Reportar uma Falha");
            System.out.println("[2] Lista de Reparos em Aberto");
            System.out.println("[3] Encerrar um Reparo");
            System.out.println("[0] Voltar");

            try {
                opcao = Integer.parseInt(scan.nextLine());
            } catch(NumberFormatException e) {
                System.out.println("Entrada Inválida!");
                continue;
            }

            switch (opcao){
                case 1:
                    // controleFalhas.algumaCoisa();
                    break;
                case 2:
                    // controleFalhas.algumaCoisa();
                    break;
                case 3:
                    // controleFalhas.algumaCoisa();
                    break;
                case 0:
                    break;
                default:
                    System.out.println("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }
}
