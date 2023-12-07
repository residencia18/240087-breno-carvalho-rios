package app;

import cliente.Imovel;
import cliente.Cliente;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ControleImoveis {

    private List<Imovel> imoveis;
    private Scanner scanner;

    public ControleImoveis() {
        this.imoveis = new ArrayList<>();
        this.scanner = new Scanner(System.in);
    }

    public void IncluirImovel() throws Exception {
        System.out.println("Informe o nome do imovel: ");
        String nome = scanner.nextLine();
        System.out.println("Informe o endereco do imovel: ");
        String endereco = scanner.nextLine();
        System.out.println("Informe penultima leitura: ");
        LocalDateTime penultimaDataCadastro = LocalDateTime.parse(scanner.nextLine());
        System.out.println("Informe ultima leitura: ");
        LocalDateTime ultimaDataCadastro = LocalDateTime.parse(scanner.nextLine());
        
        System.out.println("Informe o nome do cliente: ");
        String nomeCliente = scanner.nextLine();
        System.out.println("Informe o cpf do cliente: ");
        String cpf = scanner.nextLine();

        Cliente cliente = new Cliente(nomeCliente, cpf);
        Imovel imovel = new Imovel(nome, endereco, ultimaDataCadastro, penultimaDataCadastro, cliente);
        imoveis.add(imovel);
    }

    public void ListarImoveis(){
        for (Imovel imovel : imoveis) {
            System.out.println(imovel);
        }
    }

    public void ConsultarImovel(){
        System.out.println("Informe o nome do imovel: ");
        String nome = scanner.nextLine();
        for (Imovel imovel : imoveis) {
            if(imovel.getMatricula().equals(nome)){
                System.out.println(imovel);
            }
        }
    }

    public void AlterarImovel() throws Exception {
        System.out.println("Informe o nome do imovel: ");
        String nome = scanner.nextLine();
        for (Imovel imovel : imoveis) {
            if(imovel.getMatricula().equals(nome)){
                System.out.println("Informe o novo nome do imovel: ");
                String novoNome = scanner.nextLine();
                System.out.println("Informe o novo endereco do imovel: ");
                String novoEndereco = scanner.nextLine();
                System.out.println("Informe a nova penultima leitura: ");
                LocalDateTime novaPenultimaDataCadastro = LocalDateTime.parse(scanner.nextLine());
                System.out.println("Informe a nova ultima leitura: ");
                LocalDateTime novaUltimaDataCadastro = LocalDateTime.parse(scanner.nextLine());
                imovel.setMatricula(novoNome);
                imovel.setEndereco(novoEndereco);
                imovel.setPenultimaLeitura(novaPenultimaDataCadastro);
                imovel.setUltimaLeitura(novaUltimaDataCadastro);
            }
            else{
                System.out.println("Imovel nao encontrado");
            }
        }
    }
    public void ExcluirImovel(){
        System.out.println("Informe o nome do imovel: ");
        String matricula = scanner.nextLine();
        for (Imovel imovel : imoveis) {
            if(imovel.getMatricula().equals(matricula)){
                imoveis.remove(imovel);
            }
        }
    }


}
