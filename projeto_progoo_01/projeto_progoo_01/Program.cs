using System;

class Program
{
    const int MAX = 100;

    Fornecedor[] fornecedores = new Fornecedor[MAX];
    Produto[] produtos = new Produto[MAX];
    Transportadora[] transportadoras = new Transportadora[MAX];
    Cliente[] clientes = new Cliente[MAX];
    Pedido[] pedidos = new Pedido[MAX];

    int qtdF = 0, qtdP = 0, qtdT = 0, qtdC = 0, qtdPedidos = 0;
    int nextId = 1;

    static void Main()
    {
        Program p = new Program();
        p.Run();
    }

    void Run()
    {
        int op = -1;
        while (op != 0)
        {
            Console.WriteLine("\nMenu Principal:");
            Console.WriteLine("1. Fornecedores");
            Console.WriteLine("2. Produtos");
            Console.WriteLine("3. Transportadoras");
            Console.WriteLine("4. Clientes e Pedidos");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            if (!int.TryParse(Console.ReadLine(), out op)) continue;

            if (op == 1) MenuFornecedores();
            else if (op == 2) MenuProdutos();
            else if (op == 3) MenuTransportadoras();
            else if (op == 4) MenuClientesEPedidos();
        }
    }

    void MenuFornecedores()
    {
        int op = -1;
        while (op != 0)
        {
            Console.WriteLine("\n--- Fornecedores ---");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar");
            Console.Write("Opção: ");
            if (!int.TryParse(Console.ReadLine(), out op)) continue;

            if (op == 1) CadastrarFornecedor();
            else if (op == 2) ListarFornecedores();
            else if (op == 3) ExcluirFornecedor();
        }
    }

    void CadastrarFornecedor()
    {
        if (qtdF >= MAX)
        {
            Console.WriteLine("Limite de fornecedores atingido.");
            return;
        }

        Fornecedor f = new Fornecedor();
        f.Id = nextId++;
        Console.Write("Nome: ");
        f.Nome = Console.ReadLine();
        Console.Write("Descrição: ");
        f.Descricao = Console.ReadLine();
        Console.Write("Telefone: ");
        f.Telefone = Console.ReadLine();
        Console.Write("Email: ");
        f.Email = Console.ReadLine();

        fornecedores[qtdF++] = f;
        Console.WriteLine("Fornecedor cadastrado com sucesso!");
    }

    void ListarFornecedores()
    {
        if (qtdF == 0)
        {
            Console.WriteLine("Nenhum fornecedor cadastrado.");
            return;
        }
        for (int i = 0; i < qtdF; i++)
        {
            Console.WriteLine($"ID: {fornecedores[i].Id}, Nome: {fornecedores[i].Nome}, Telefone: {fornecedores[i].Telefone}");
        }
    }

    void ExcluirFornecedor()
    {
        Console.Write("Digite o ID do fornecedor a excluir: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        for (int i = 0; i < qtdF; i++)
        {
            if (fornecedores[i].Id == id)
            {
                for (int j = i; j < qtdF - 1; j++)
                    fornecedores[j] = fornecedores[j + 1];
                fornecedores[qtdF - 1] = null;
                qtdF--;
                Console.WriteLine("Fornecedor excluído!");
                return;
            }
        }
        Console.WriteLine("Fornecedor não encontrado.");
    }

    void MenuProdutos()
    {
        int op = -1;
        while (op != 0)
        {
            Console.WriteLine("\n--- Produtos ---");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar");
            Console.Write("Opção: ");
            if (!int.TryParse(Console.ReadLine(), out op)) continue;

            if (op == 1) CadastrarProduto();
            else if (op == 2) ListarProdutos();
            else if (op == 3) ExcluirProduto();
        }
    }

    void CadastrarProduto()
    {
        if (qtdP >= MAX)
        {
            Console.WriteLine("Limite de produtos atingido.");
            return;
        }

        Produto p = new Produto();
        p.Id = nextId++;
        Console.Write("Nome do Produto: ");
        p.Nome = Console.ReadLine();
        Console.Write("Valor: ");
        if (!double.TryParse(Console.ReadLine(), out double val)) return;
        p.Valor = val;
        Console.Write("Quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out int qtd)) return;
        p.Quantidade = qtd;

        Console.WriteLine("Fornecedores disponíveis:");
        ListarFornecedores();
        Console.Write("ID do Fornecedor: ");
        if (!int.TryParse(Console.ReadLine(), out int idF)) return;

        p.Fornecedor = null;
        for (int i = 0; i < qtdF; i++)
        {
            if (fornecedores[i].Id == idF)
            {
                p.Fornecedor = fornecedores[i];
                break;
            }
        }
        if (p.Fornecedor == null)
        {
            Console.WriteLine("Fornecedor não encontrado. Produto não cadastrado.");
            return;
        }

        produtos[qtdP++] = p;
        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    void ListarProdutos()
    {
        if (qtdP == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }
        for (int i = 0; i < qtdP; i++)
        {
            string fornecedorNome = produtos[i].Fornecedor != null ? produtos[i].Fornecedor.Nome : "Nenhum";
            Console.WriteLine($"ID: {produtos[i].Id}, Nome: {produtos[i].Nome}, Fornecedor: {fornecedorNome}");
        }
    }

    void ExcluirProduto()
    {
        Console.Write("Digite o ID do produto a excluir: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        for (int i = 0; i < qtdP; i++)
        {
            if (produtos[i].Id == id)
            {
                for (int j = i; j < qtdP - 1; j++)
                    produtos[j] = produtos[j + 1];
                produtos[qtdP - 1] = null;
                qtdP--;
                Console.WriteLine("Produto excluído!");
                return;
            }
        }
        Console.WriteLine("Produto não encontrado.");
    }

    void MenuTransportadoras()
    {
        int op = -1;
        while (op != 0)
        {
            Console.WriteLine("\n--- Transportadoras ---");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar");
            Console.Write("Opção: ");
            if (!int.TryParse(Console.ReadLine(), out op)) continue;

            if (op == 1) CadastrarTransportadora();
            else if (op == 2) ListarTransportadoras();
            else if (op == 3) ExcluirTransportadora();
        }
    }

    void CadastrarTransportadora()
    {
        if (qtdT >= MAX)
        {
            Console.WriteLine("Limite de transportadoras atingido.");
            return;
        }

        Transportadora t = new Transportadora();
        t.Id = nextId++;
        Console.Write("Nome: ");
        t.Nome = Console.ReadLine();
        Console.Write("Preço por km: ");
        if (!double.TryParse(Console.ReadLine(), out double preco)) return;
        t.PrecoPorKm = preco;

        transportadoras[qtdT++] = t;
        Console.WriteLine("Transportadora cadastrada!");
    }

    void ListarTransportadoras()
    {
        if (qtdT == 0)
        {
            Console.WriteLine("Nenhuma transportadora cadastrada.");
            return;
        }
        for (int i = 0; i < qtdT; i++)
        {
            Console.WriteLine($"ID: {transportadoras[i].Id}, Nome: {transportadoras[i].Nome}, Preço por km: {transportadoras[i].PrecoPorKm}");
        }
    }

    void ExcluirTransportadora()
    {
        Console.Write("Digite o ID da transportadora a excluir: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        for (int i = 0; i < qtdT; i++)
        {
            if (transportadoras[i].Id == id)
            {
                for (int j = i; j < qtdT - 1; j++)
                    transportadoras[j] = transportadoras[j + 1];
                transportadoras[qtdT - 1] = null;
                qtdT--;
                Console.WriteLine("Transportadora excluída!");
                return;
            }
        }
        Console.WriteLine("Transportadora não encontrada.");
    }

    void MenuClientesEPedidos()
    {
        int op = -1;
        while (op != 0)
        {
            Console.WriteLine("\n--- Clientes e Pedidos ---");
            Console.WriteLine("1. Cadastrar Cliente");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Excluir Cliente");
            Console.WriteLine("4. Cadastrar Pedido");
            Console.WriteLine("5. Listar Pedidos");
            Console.WriteLine("0. Voltar");
            Console.Write("Opção: ");
            if (!int.TryParse(Console.ReadLine(), out op)) continue;

            if (op == 1) CadastrarCliente();
            else if (op == 2) ListarClientes();
            else if (op == 3) ExcluirCliente();
            else if (op == 4) CadastrarPedido();
            else if (op == 5) ListarPedidos();
        }
    }

    void CadastrarCliente()
    {
        if (qtdC >= MAX)
        {
            Console.WriteLine("Limite de clientes atingido.");
            return;
        }

        Cliente c = new Cliente();
        c.Id = nextId++;
        Console.Write("Nome: ");
        c.Nome = Console.ReadLine();
        Console.Write("Telefone: ");
        c.Telefone = Console.ReadLine();
        Console.Write("Email: ");
        c.Email = Console.ReadLine();

        c.Endereco = new Endereco();
        Console.Write("Rua: ");
        c.Endereco.Rua = Console.ReadLine();
        Console.Write("Número: ");
        c.Endereco.Numero = Console.ReadLine();

        clientes[qtdC++] = c;
        Console.WriteLine("Cliente cadastrado!");
    }

    void ListarClientes()
    {
        if (qtdC == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return;
        }
        for (int i = 0; i < qtdC; i++)
        {
            Console.WriteLine($"ID: {clientes[i].Id}, Nome: {clientes[i].Nome}, Telefone: {clientes[i].Telefone}");
        }
    }

    void ExcluirCliente()
    {
        Console.Write("Digite o ID do cliente a excluir: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        for (int i = 0; i < qtdC; i++)
        {
            if (clientes[i].Id == id)
            {
                for (int j = i; j < qtdC - 1; j++)
                    clientes[j] = clientes[j + 1];
                clientes[qtdC - 1] = null;
                qtdC--;
                Console.WriteLine("Cliente excluído!");
                return;
            }
        }
        Console.WriteLine("Cliente não encontrado.");
    }

    void CadastrarPedido()
    {
        if (qtdPedidos >= MAX)
        {
            Console.WriteLine("Limite de pedidos atingido.");
            return;
        }

        Pedido p = new Pedido();
        p.Numero = nextId++;

        Console.WriteLine("Clientes disponíveis:");
        ListarClientes();
        Console.Write("ID do cliente: ");
        if (!int.TryParse(Console.ReadLine(), out int idC)) return;

        p.Cliente = null;
        for (int i = 0; i < qtdC; i++)
        {
            if (clientes[i].Id == idC)
            {
                p.Cliente = clientes[i];
                break;
            }
        }
        if (p.Cliente == null)
        {
            Console.WriteLine("Cliente não encontrado. Pedido não cadastrado.");
            return;
        }

        p.DataHoraPedido = DateTime.Now;
        p.Situacao = "Em andamento";
        p.QtdItens = 0;

        char mais = 's';
        while (mais == 's' || mais == 'S')
        {
            Console.WriteLine("Produtos disponíveis:");
            ListarProdutos();

            PedidoItem item = new PedidoItem();

            Console.Write("ID do Produto: ");
            if (!int.TryParse(Console.ReadLine(), out int idP)) break;

            item.Produto = null;
            for (int i = 0; i < qtdP; i++)
            {
                if (produtos[i].Id == idP)
                {
                    item.Produto = produtos[i];
                    break;
                }
            }
            if (item.Produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                break;
            }

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int qtd)) break;

            item.Quantidade = qtd;
            item.PrecoTotal = item.Produto.Valor * item.Quantidade;

            if (p.QtdItens < Pedido.MAX_ITENS)
                p.Itens[p.QtdItens++] = item;
            else
            {
                Console.WriteLine("Máximo de itens no pedido atingido.");
                break;
            }

            Console.Write("Deseja adicionar mais produtos? (s/n): ");
            mais = Console.ReadLine().Length > 0 ? Console.ReadLine()[0] : 'n';
        }

        Console.Write("Deseja transporte? (s/n): ");
        char t = Console.ReadLine().Length > 0 ? Console.ReadLine()[0] : 'n';
        if (t == 's' || t == 'S')
        {
            ListarTransportadoras();
            Console.Write("ID da Transportadora: ");
            if (!int.TryParse(Console.ReadLine(), out int idT)) return;

            p.Transportadora = null;
            for (int i = 0; i < qtdT; i++)
            {
                if (transportadoras[i].Id == idT)
                {
                    p.Transportadora = transportadoras[i];
                    break;
                }
            }
            if (p.Transportadora != null)
            {
                double distancia = 10; // distância fixa para exemplo
                p.PrecoFrete = p.Transportadora.PrecoPorKm * distancia;
            }
            else
            {
                Console.WriteLine("Transportadora não encontrada.");
            }
        }

        pedidos[qtdPedidos++] = p;
        Console.WriteLine("Pedido cadastrado com sucesso!");
    }

    void ListarPedidos()
    {
        if (qtdPedidos == 0)
        {
            Console.WriteLine("Nenhum pedido cadastrado.");
            return;
        }
        for (int i = 0; i < qtdPedidos; i++)
        {
            Pedido p = pedidos[i];
            Console.WriteLine($"Pedido #{p.Numero} - Cliente: {p.Cliente.Nome} - Frete: {p.PrecoFrete}");
            for (int j = 0; j < p.QtdItens; j++)
            {
                Console.WriteLine($"  Produto: {p.Itens[j].Produto.Nome} x {p.Itens[j].Quantidade} (Total: {p.Itens[j].PrecoTotal})");
            }
        }
    }
}

// Classes auxiliares:

class Fornecedor
{
    public int Id;
    public string Nome;
    public string Descricao;
    public string Telefone;
    public string Email;
}

class Produto
{
    public int Id;
    public string Nome;
    public double Valor;
    public int Quantidade;
    public Fornecedor Fornecedor;
}

class Transportadora
{
    public int Id;
    public string Nome;
    public double PrecoPorKm;
}

class Cliente
{
    public int Id;
    public string Nome;
    public string Telefone;
    public string Email;
    public Endereco Endereco;
}

class Endereco
{
    public string Rua;
    public string Numero;
}

class Pedido
{
    public const int MAX_ITENS = 20;

    public int Numero;
    public Cliente Cliente;
    public DateTime DataHoraPedido;
    public string Situacao;
    public PedidoItem[] Itens = new PedidoItem[MAX_ITENS];
    public int QtdItens = 0;
    public Transportadora Transportadora;
    public double PrecoFrete;
}

class PedidoItem
{
    public Produto Produto;
    public int Quantidade;
    public double PrecoTotal;
}
