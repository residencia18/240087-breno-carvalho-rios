def insertProduct(productList):
    print("Inserir Novo Produto: ")
    print("--------------------")

    code = input("Digite o código do novo produto (13 Dígitos): ")
    if(len(code) != 13):
        print("O código deve conter 13 dítigos!")
        return

    if code in [product['code'] for product in productList]:
        print("O código deve ser único!")
        return

    name = input("Digite o nome do novo produto: ").capitalize()
    if(not name or not name.strip()):
        print("O nome não pode estar em branco!")
        return
    
    price = input("Digite o preço do novo produto: ")
    try:
        price = float(price)
    except:
        print("Por favor digite um preço válido")
        return
    
    newProduct = {
        'code': code,
        'name': name,
        'price': price
    }

    productList.append(newProduct)
    print("Produto Adicionado com Sucesso!")

def consultProduct(productList):
    print("Consultar Produto: ")
    print("--------------------")

    code = input("Digite o código do produto: ")
    product = findProduct(productList, code)

    if(not product):
        return False

    print(toString(product))

def deleteProduct(productList):
    print("Excluir Produto: ")
    print("--------------------")

    code = input("Digite o código do produto: ")
    product = findProduct(productList, code)

    if(not product):
        return False
    
    productList.remove(product)
    print("Produto Excluído com Sucesso!")

def listProducts(productList):
    print("Lista de Produtos: ")
    print("--------------------")

    productList.sort(key=lambda x: x['price'])

    for index, product in enumerate(productList):
        if((index + 1) % 11 == 0):
            input("Pressione uma tecla para ver mais resultados...")
            
        print(toString(product))

def findProduct(productList, code):
    for product in productList:
        if(product['code'] == code):
            return product
    
    print("Produto não encontrado!")
    return False

def toString(product):
    return f"[ {product['code']} ] {product['name']} - R$ {'{:.2f}'.format(product['price'])}"
        
def showMenu():
    print("----------Menu----------")
    print("1. Inserir Produto")
    print("2. Consultar Produto")
    print("3. Excluir Produto")
    print("4. Listar Produtos")
    print("0. Sair")
    print("------------------------")

def main():
    productList = []

    while True:
        showMenu()
        op = input("Digite uma opção: ")
        try:
            op = int(op)
        except:
            print("Por favor digite um número válido")

        match op:
            case 1:
                insertProduct(productList)
            case 2:
                consultProduct(productList)
            case 3:
                deleteProduct(productList)
            case 4:
                listProducts(productList)
            case 0:
                break
            case _:
                print("Opção Inválida")


if __name__ == "__main__":
    main()