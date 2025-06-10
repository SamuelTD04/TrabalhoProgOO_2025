using System;

public class Pedido
{
    public int Id { get; set; }
    public DateTime DataHoraPedido { get; set; }
    public string Situacao { get; set; }
    public double PrecoFrete { get; set; }
    public Cliente Cliente { get; set; }
    public Transportadora Transportadora { get; set; }
    public PedidoItem[] Itens { get; set; } = new PedidoItem[0];

    private static Pedido[] pedidos = new Pedido[0];
    private static int nextId = 1;

    public static int GetNextId()
    {
        return nextId;
    }
    
    public static void IncrementarNextId()
    {
        nextId++;
    }
    
    public static void DecrementarNextId()
    {
        if (nextId > 1)
        {
            nextId--;
        }
    }

    public static void Cadastrar()
    {
        try
        {
            Pedido p = new Pedido();
            p.Id = nextId++;
            p.DataHoraPedido = DateTime.Now;
            p.Situacao = "Em andamento";

            Gerenciador.MostrarMensagem("Clientes:");
            Cliente.Listar();
            p.Cliente = Cliente.BuscarPorId(Gerenciador.LerInteiro("ID Cliente: "));
            
            if (p.Cliente == null)
            {
                Gerenciador.MostrarErro("Cliente não encontrado!");
                DecrementarNextId();
                return;
            }

            PedidoItem[] novosItens = new PedidoItem[0];

            do
            {
                try
                {
                    PedidoItem item = new PedidoItem();
                    Gerenciador.MostrarMensagem("Produtos:");
                    Produto.Listar();
                    
                    int produtoId = Gerenciador.LerInteiro("ID Produto: ");
                    item.Produto = Produto.BuscarPorId(produtoId);
                    
                    if (item.Produto == null)
                    {
                        Gerenciador.MostrarErro($"Produto com ID {produtoId} não encontrado!");
                        continue; // Volta para o início do loop para tentar novamente
                    }
                    
                    item.Quantidade = Gerenciador.LerInteiro("Quantidade: ");
                    
                    if (item.Quantidade <= 0)
                    {
                        Gerenciador.MostrarErro("Quantidade deve ser maior que zero!");
                        continue;
                    }
                    
                    if (item.Quantidade > item.Produto.Quantidade)
                    {
                        Gerenciador.MostrarErro($"Quantidade indisponível! Disponível: {item.Produto.Quantidade}");
                        continue;
                    }
                    
                    item.PrecoTotal = item.Produto.Valor * item.Quantidade;

                    PedidoItem[] temp = new PedidoItem[novosItens.Length + 1];
                    for (int i = 0; i < novosItens.Length; i++)
                    {
                        temp[i] = novosItens[i];
                    }
                    temp[temp.Length - 1] = item;
                    novosItens = temp;

                }
                catch (Exception ex)
                {
                    Gerenciador.MostrarErro($"Erro ao adicionar item: {ex.Message}");
                }

            } while (Gerenciador.Confirmar("Adicionar mais produtos?"));

            if (novosItens.Length == 0)
            {
                Gerenciador.MostrarErro("Pedido não pode ser criado sem itens!");
                DecrementarNextId();
                return;
            }

            p.Itens = novosItens;

            if (Gerenciador.Confirmar("Adicionar transportadora?"))
            {
                Transportadora.Listar();
                int transportadoraId = Gerenciador.LerInteiro("ID Transportadora: ");
                p.Transportadora = Transportadora.BuscarPorId(transportadoraId);
                
                if (p.Transportadora == null)
                {
                    Gerenciador.MostrarErro($"Transportadora com ID {transportadoraId} não encontrada!");
                }
                else
                {
                    p.PrecoFrete = p.Transportadora.PrecoPorKm * Gerenciador.LerDouble("Distância (km): ");
                }
            }

            Pedido[] novosPedidos = new Pedido[pedidos.Length + 1];
            for (int i = 0; i < pedidos.Length; i++)
            {
                novosPedidos[i] = pedidos[i];
            }
            novosPedidos[novosPedidos.Length - 1] = p;
            pedidos = novosPedidos;

            Gerenciador.MostrarMensagem("Pedido cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Gerenciador.MostrarErro($"Erro ao cadastrar pedido: {ex.Message}");
            DecrementarNextId();
        }
    }

    public static void Listar()
    {
        for (int i = 0; i < pedidos.Length; i++)
        {
            Console.WriteLine($"\nPedido #{pedidos[i].Id}");
            Console.WriteLine($"Cliente: {pedidos[i].Cliente.Nome}");
            Console.WriteLine($"Data: {pedidos[i].DataHoraPedido:dd/MM/yyyy}");

            double total = 0;
            for (int j = 0; j < pedidos[i].Itens.Length; j++)
            {
                Console.WriteLine($"- {pedidos[i].Itens[j].Produto.Nome} x{pedidos[i].Itens[j].Quantidade} = R${pedidos[i].Itens[j].PrecoTotal}");
                total += pedidos[i].Itens[j].PrecoTotal;
            }

            if (pedidos[i].Transportadora != null)
            {
                Console.WriteLine($"Frete: R${pedidos[i].PrecoFrete}");
                total += pedidos[i].PrecoFrete;
            }

            Console.WriteLine($"Total: R${total}");
        }
    }

    public static Pedido BuscarPorId(int id)
    {
        for (int i = 0; i < pedidos.Length; i++)
        {
            if (pedidos[i].Id == id)
            {
                return pedidos[i];
            }
        }
        return null;
    }
}