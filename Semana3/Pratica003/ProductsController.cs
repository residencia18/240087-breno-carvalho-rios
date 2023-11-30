namespace Pratica003;

public class ProductsController {
    public List<Product> productList { get; private set; }

    public ProductsController(){
        this.productList = new();
    }

    public void run(){
        while(true) {
            Console.WriteLine($"----------Menu----------");
            Console.WriteLine($"1. Cadastrar Produto");
            Console.WriteLine($"2. Consultar Produto");
            Console.WriteLine($"3. Entrada de Produtos");
            Console.WriteLine($"4. Saída de Produtos");
            Console.WriteLine($"5. Relatórios");
            Console.WriteLine($"0. Sair");

            int op;
            try {
                op = int.Parse(Console.ReadLine()!);
            } catch (FormatException) {
                Console.WriteLine($"Digite uma opção válida!");
                continue;
            } catch (Exception e) {
                Console.WriteLine($"{e.Message}");
                continue;
            }

            switch(op) {
                case 1:
                    this.insertProduct();
                    break;
                case 2:
                    this.showProductInfo();
                    break;
                case 3:
                    this.stockEntry();
                    break;
                case 4:
                    this.stockExit();
                    break;
                case 5:
                    this.showReportMenu();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine($"Opção Inválida");
                    break;                    
            }

            if(op == 0){
                break;
            }
        }
    }

    public void showReportMenu(){
        while(true) {
            Console.WriteLine($"----------Menu----------");
            Console.WriteLine($"1. Produtos com estoque abaixo de um limite");
            Console.WriteLine($"2. Produtos em determinada faixa de preço");
            Console.WriteLine($"3. Total de estoque e preços");
            Console.WriteLine($"0. Voltar");

            int op;
            try {
                op = int.Parse(Console.ReadLine()!);
            } catch (FormatException) {
                Console.WriteLine($"Digite uma opção válida!");
                continue;
            } catch (Exception e) {
                Console.WriteLine($"{e.Message}");
                continue;
            }

            switch(op) {
                case 1:
                    this.belowStockTresholdReport();
                    break;
                case 2:
                    this.priceInRangeReport();
                    break;
                case 3:
                    this.totalStockReport();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine($"Opção Inválida");
                    break;                    
            }

            if(op == 0){
                break;
            }
        }
    }

    public bool insertProduct(){
        Console.WriteLine($"Digite o código do produto: ");
        string cod = Console.ReadLine()!;
        if(String.IsNullOrWhiteSpace(cod)){
            Console.WriteLine($"Por favor preencha todos os dados.");
            return false;
        }

        if(this.productList.Any(product => product.Cod == cod)){
            Console.WriteLine($"O código deve ser único!");
            return false;
        }

        Console.WriteLine($"Digite o nome do produto: ");
        string name = Console.ReadLine()!;
        if(String.IsNullOrWhiteSpace(name)){
            Console.WriteLine($"Por favor preencha todos os dados.");
            return false;
        }

        Console.WriteLine($"Digite o preço do produto: ");
        float price;
        try {
            price = float.Parse(Console.ReadLine()!);
        } catch (FormatException) {
            Console.WriteLine($"Digite um preço válido!");
            return false;     
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");
            return false;  
        }
        
        Console.WriteLine($"Digite a quantidade em estoque do produto: ");
        int stock;
        try {
            stock = int.Parse(Console.ReadLine()!);
        } catch (FormatException) {
            Console.WriteLine($"Digite uma quantidade válida!");
            return false;
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");
            return false;
        }

        Product newProduct = new Product(cod, name, price, stock);
        this.productList.Add(newProduct);

        return true;
    }

    public void showProductInfo() {
        try {
            Product product = this.searchProduct();
            Console.WriteLine(product.ToString());
        } catch (FormatException) {
            Console.WriteLine($"Entrada inválida");            
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");  
        }
    }

    public Boolean stockEntry(){
        Product product;
        try {
            product = this.searchProduct();
        } catch(Exceptions.ItemNotFoundException e) {
            Console.WriteLine($"{e.Message}");
            return false;
        }

        Console.WriteLine($"Digite qual foi a entrada do produto: ");

        try {
            int entry = int.Parse(Console.ReadLine()!);
            product.addStock(entry);
            Console.WriteLine($"Estoque Atualizado: ");
            Console.WriteLine(product.ToString());
            return true;
        } catch (FormatException) {
            Console.WriteLine($"Entrada inválida");            
        } catch (Exceptions.NegativeStockChange e) {
            Console.WriteLine($"Problema de estoque: {e.Message}"); 
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");  
        }

        return false;
    }

        public Boolean stockExit(){
        Product product;
        try {
            product = this.searchProduct();
        } catch(Exceptions.ItemNotFoundException e) {
            Console.WriteLine($"{e.Message}");
            return false;
        }

        Console.WriteLine($"Digite qual foi a saída do produto: ");

        try {
            int exit = int.Parse(Console.ReadLine()!);
            product.subStock(exit);
            Console.WriteLine($"Estoque Atualizado: ");
            Console.WriteLine(product.ToString());
            return true;
        } catch (FormatException) {
            Console.WriteLine($"Entrada inválida");            
        } catch (Exceptions.NegativeStockChange e) {
            Console.WriteLine($"Problema de estoque: {e.Message}"); 
        } catch (Exceptions.InsufficientStock e) {
            Console.WriteLine($"Problema de estoque: {e.Message}"); 
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");  
        }

        return false;
    }

    public Product searchProduct(){
        Console.WriteLine($"Digite o código do produto: ");
        string cod = Console.ReadLine()!;
        Product? product = this.productList.Find(produto => produto.Cod == cod) ?? throw new Exceptions.ItemNotFoundException("Produto não encontrado.");
        return product;
    }

    public void belowStockTresholdReport(){
        Console.WriteLine($"Digite a quantidade minima em estoque: ");
        int stock;
        try {
            stock = int.Parse(Console.ReadLine()!);
        } catch (FormatException) {
            Console.WriteLine($"Digite uma quantidade válida!");
            return;
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");
            return;
        }

        foreach (Product product in this.productList.Where(product => product.Stock <= stock).ToList()) {
            Console.WriteLine(product.ToString());
        }
    }

    public void priceInRangeReport(){
        Console.WriteLine($"Digite o preço mínimo: ");
        int minPrice;
        try {
            minPrice = int.Parse(Console.ReadLine()!);
        } catch (FormatException) {
            Console.WriteLine($"Digite uma quantidade válida!");
            return;
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");
            return;
        }

        Console.WriteLine($"Digite o preço máximo: ");
        int maxPrice;
        try {
            maxPrice = int.Parse(Console.ReadLine()!);
        } catch (FormatException) {
            Console.WriteLine($"Digite uma quantidade válida!");
            return;
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");
            return;
        }

        foreach (Product product in this.productList.Where(product => product.Price >= minPrice && product.Price <= maxPrice).ToList()) {
            Console.WriteLine(product.ToString());
        }
    }

    public void totalStockReport(){
        Console.WriteLine($"Em Estoque: {this.productList.Sum(x => x.Stock)} itens | Total: {this.productList.Sum(x => x.Stock * x.Price).ToString("c2")}");
        foreach(Product product in this.productList) {
            Console.WriteLine($"Nome: {product.Name} | Itens: {product.Stock} | Preço: {product.Price.ToString("c2")} | Total: {product.totalPrice().ToString("c2")}");
        }
    }
}
