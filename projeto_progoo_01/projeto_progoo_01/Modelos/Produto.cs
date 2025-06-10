using System;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public Fornecedor Fornecedor { get; set; }

    private static Produto[] produtos = new Produto[0];
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
        Produto p = new Produto();
        p.Id = nextId++;
        p.Nome = Gerenciador.LerString("Nome: ");
        p.Valor = Gerenciador.LerDouble("Valor: ");
        p.Quantidade = Gerenciador.LerInteiro("Quantidade: ");

        Gerenciador.MostrarMensagem("Fornecedores:");
        Fornecedor.Listar();

        p.Fornecedor = Fornecedor.BuscarPorId(Gerenciador.LerInteiro("ID Fornecedor: "));

        Produto[] novosProdutos = new Produto[produtos.Length + 1];
        for (int i = 0; i < produtos.Length; i++)
        {
            novosProdutos[i] = produtos[i];
        }

        novosProdutos[novosProdutos.Length - 1] = p;
        produtos = novosProdutos;

        Gerenciador.MostrarMensagem("Produto cadastrado com sucesso!");
    }

    public static void Listar()
    {
        foreach (Produto p in produtos)
        {
            Console.WriteLine($"ID: {p.Id}, Nome: {p.Nome}, Valor: {p.Valor}");
        }
    }

    public static void Excluir()
    {
        int id = Gerenciador.LerInteiro("ID para excluir: ");

        int index = -1;
        for (int i = 0; i < produtos.Length; i++)
        {
            if (produtos[i].Id == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Gerenciador.MostrarErro("Produto não encontrado!");
            return;
        }

        Produto[] atualizados = new Produto[produtos.Length - 1];
        int j = 0;
        for (int i = 0; i < produtos.Length; i++)
        {
            if (i != index)
            {
                atualizados[j++] = produtos[i];
            }
        }

        produtos = atualizados;
        Gerenciador.MostrarMensagem("Produto excluído com sucesso!");
    }

    public static Produto BuscarPorId(int id)
    {
        foreach (Produto p in produtos)
        {
            if (p.Id == id)
            {
                return p;
            }
        }
        return null;
    }
}