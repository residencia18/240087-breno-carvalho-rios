def inserir_produto(produtos):
    codigo = input("Digite o código do produto: ")
    nome = input("Digite o nome do produto: ").capitalize()
    preco = float(input("Digite o preço do produto: "))
    
    produto = {"codigo": codigo, "nome": nome, "preco": preco}
    produtos.append(produto)
    print("Produto inserido com sucesso!\n")

def excluir_produto(produtos):
    codigo = input("Digite o código do produto a ser excluído: ")
    for produto in produtos:
        if produto["codigo"] == codigo:
            produtos.remove(produto)
            print("Produto excluído com sucesso!\n")
            return
    print("Produto não encontrado!\n")

def listar_produtos(produtos):
    print("\nLista de Produtos:")
    for produto in produtos:
        print(f"Código: {produto['codigo']}, Nome: {produto['nome']}, Preço: R${produto['preco']:.2f}")
    print()

def consultar_preco(produtos):
    codigo = input("Digite o código do produto para consultar o preço: ")
    for produto in produtos:
        if produto["codigo"] == codigo:
            print(f"O preço do produto {produto['nome']} é R${produto['preco']:.2f}\n")
            return
    print("Produto não encontrado!\n")

def main():
     produtos = []

     while True:
        print("Menu de Opções:")
        print("1. Inserir novo produto")
        print("2. Excluir produto cadastrado")
        print("3. Listar todos os produtos")
        print("4. Consultar preço de um produto")
        print("0. Sair")

        opcao = input("Escolha uma opção: ")

        if opcao == "1":
            inserir_produto(produtos)
        elif opcao == "2":
            excluir_produto(produtos)
        elif opcao == "3":
            listar_produtos(produtos)
        elif opcao == "4":
            consultar_preco(produtos)
        elif opcao == "0":
            print("Saindo do programa. Até mais!")
            break
        else:
            print("Opção inválida. Tente novamente.\n")

if __name__ == "__main__":
    main()


