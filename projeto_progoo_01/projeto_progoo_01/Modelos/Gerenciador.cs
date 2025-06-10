using System;

public static class Gerenciador
{
    // === MENUS PRINCIPAIS ===

    public static void MostrarMenuAdmin()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU ADMIN ===");
            Console.WriteLine("1. Fornecedores");
            Console.WriteLine("2. Produtos");
            Console.WriteLine("3. Transportadoras");
            Console.WriteLine("4. Clientes");
            Console.WriteLine("5. Pedidos");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    MostrarSubMenuFornecedores();
                    break;
                case 2:
                    MostrarSubMenuProdutos();
                    break;
                case 3:
                    MostrarSubMenuTransportadoras();
                    break;
                case 4:
                    MostrarSubMenuClientes();
                    break;
                case 5:
                    MostrarSubMenuPedidos();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

        } while (op != 0);
    }

    public static void MostrarMenuCliente()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU CLIENTE ===");
            Console.WriteLine("1. Listar Produtos");
            Console.WriteLine("2. Fazer Pedido");
            Console.WriteLine("3. Ver Pedidos");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    Produto.Listar();
                    break;
                case 2:
                    Pedido.Cadastrar();
                    break;
                case 3:
                    Pedido.Listar();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

            //Pausar();
        } while (op != 0);
    }

    public static void MostrarMenuTransportadora()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU TRANSPORTADORA ===");
            Console.WriteLine("1. Visualizar Dados");
            Console.WriteLine("2. Atualizar Preço");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    Transportadora.Listar();
                    break;
                case 2:
                    AtualizarPrecoTransportadora();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

            //Pausar();
        } while (op != 0);
    }

    public static void MostrarMenuFornecedor()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU FORNECEDOR ===");
            Console.WriteLine("1. Visualizar Dados");
            Console.WriteLine("2. Cadastrar Produto");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    Fornecedor.Listar();
                    break;
                case 2:
                    Produto.Cadastrar();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

            //Pausar();
        } while (op != 0);
    }

    // === SUBMENUS ===

    private static void MostrarSubMenuFornecedores()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU FORNECEDORES ===");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    Fornecedor.Cadastrar();
                    break;
                case 2:
                    Fornecedor.Listar();
                    break;
                case 3:
                    Fornecedor.Excluir();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

            //Pausar();
        } while (op != 0);
    }

    private static void MostrarSubMenuProdutos()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU PRODUTOS ===");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    Produto.Cadastrar();
                    break;
                case 2:
                    Produto.Listar();
                    break;
                case 3:
                    Produto.Excluir();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

            //Pausar();
        } while (op != 0);
    }

    private static void MostrarSubMenuTransportadoras()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU TRANSPORTADORAS ===");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    Transportadora.Cadastrar();
                    break;
                case 2:
                    Transportadora.Listar();
                    break;
                case 3:
                    Transportadora.Excluir();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

            //Pausar();
        } while (op != 0);
    }

    private static void MostrarSubMenuClientes()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU CLIENTES ===");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Excluir");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    Cliente.Cadastrar();
                    break;
                case 2:
                    Cliente.Listar();
                    break;
                case 3:
                    Cliente.Excluir();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

            //Pausar();
        } while (op != 0);
    }

    private static void MostrarSubMenuPedidos()
    {
        int op;
        do
        {
            //Console.Clear();
            Console.WriteLine("=== MENU PEDIDOS ===");
            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("0. Voltar");

            op = LerInteiro("Opção: ");

            switch (op)
            {
                case 1:
                    Pedido.Cadastrar();
                    break;
                case 2:
                    Pedido.Listar();
                    break;
                case 0:
                    break;
                default:
                    MostrarErro("Opção inválida!");
                    break;
            }

            //Pausar();
        } while (op != 0);
    }

    private static void AtualizarPrecoTransportadora()
    {
        int id = LerInteiro("ID da Transportadora: ");
        var transp = Transportadora.BuscarPorId(id);

        if (transp != null)
        {
            transp.PrecoPorKm = LerDouble("Novo preço por KM: ");
            MostrarMensagem("Preço atualizado!");
        }
        else
        {
            MostrarErro("Transportadora não encontrada!");
        }
    }

    // === MÉTODOS DE UTILIDADE ===

    public static int LerInteiro(string msg)
    {
        Console.Write(msg);
        return int.Parse(Console.ReadLine());
    }

    public static double LerDouble(string msg)
    {
        Console.Write(msg);
        return double.Parse(Console.ReadLine());
    }

    public static string LerString(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine();
    }

    public static void MostrarMensagem(string msg)
    {
        Console.WriteLine(msg);
    }

    public static void MostrarErro(string msg)
    {
        Console.WriteLine($"Erro: {msg}");
    }

    public static void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public static bool Confirmar(string msg)
    {
        Console.Write($"{msg} (s/n): ");
        return Console.ReadLine().ToLower() == "s";
    }
}