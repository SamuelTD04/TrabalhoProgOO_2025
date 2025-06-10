using System;

public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Descricao { get; set; }

    private static Fornecedor[] fornecedores = new Fornecedor[0];
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
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Fornecedor novo = new Fornecedor();
        novo.Id = nextId++;
        novo.Nome = nome;
        novo.Descricao = descricao;
        novo.Telefone = telefone;
        novo.Email = email;

        Fornecedor[] novosFornecedores = new Fornecedor[fornecedores.Length + 1];
        for (int i = 0; i < fornecedores.Length; i++)
        {
            novosFornecedores[i] = fornecedores[i];
        }

        novosFornecedores[novosFornecedores.Length - 1] = novo;
        fornecedores = novosFornecedores;

        Console.WriteLine("Fornecedor cadastrado com sucesso!");
    }

    public static void Listar()
    {
        foreach (Fornecedor f in fornecedores)
        {
            Console.WriteLine($"ID: {f.Id}, Nome: {f.Nome}");
        }
    }

    public static void Excluir()
    {
        Console.Write("ID para excluir: ");
        int id = int.Parse(Console.ReadLine());

        int index = -1;
        for (int i = 0; i < fornecedores.Length; i++)
        {
            if (fornecedores[i].Id == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Fornecedor não encontrado!");
            return;
        }

        Fornecedor[] atualizados = new Fornecedor[fornecedores.Length - 1];
        int j = 0;
        for (int i = 0; i < fornecedores.Length; i++)
        {
            if (i != index)
            {
                atualizados[j++] = fornecedores[i];
            }
        }

        fornecedores = atualizados;
        Console.WriteLine("Fornecedor excluído com sucesso!");
    }

    public static Fornecedor BuscarPorId(int id)
    {
        foreach (Fornecedor f in fornecedores)
        {
            if (f.Id == id)
            {
                return f;
            }
        }
        return null;
    }
}