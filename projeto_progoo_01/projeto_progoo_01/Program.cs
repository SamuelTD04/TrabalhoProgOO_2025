using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            //Console.Clear();
            Console.WriteLine("=== SISTEMA DE GERENCIAMENTO ===");
            Console.WriteLine("1. Administrador");
            Console.WriteLine("2. Cliente");
            Console.WriteLine("3. Transportadora");
            Console.WriteLine("4. Fornecedor");
            Console.WriteLine("0. Sair");

            int opcao = Gerenciador.LerInteiro("Opção: ");

            switch (opcao)
            {
                case 1:
                    Gerenciador.MostrarMenuAdmin();
                    break;
                case 2:
                    Gerenciador.MostrarMenuCliente();
                    break;
                case 3:
                    Gerenciador.MostrarMenuTransportadora();
                    break;
                case 4:
                    Gerenciador.MostrarMenuFornecedor();
                    break;
                case 0:
                    return;
                default:
                    Gerenciador.MostrarErro("Opção inválida!");
                    break;
            }

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
