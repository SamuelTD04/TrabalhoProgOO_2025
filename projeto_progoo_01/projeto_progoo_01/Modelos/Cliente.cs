public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public Endereco Endereco { get; set; }

    private static Cliente[] clientes = new Cliente[0];
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
        Cliente c = new Cliente();
        c.Id = nextId;
        nextId++;
        c.Nome = Gerenciador.LerString("Nome: ");
        c.Telefone = Gerenciador.LerString("Telefone: ");
        c.Email = Gerenciador.LerString("Email: ");

        c.Endereco = new Endereco();
        c.Endereco.Rua = Gerenciador.LerString("Rua: ");
        c.Endereco.Numero = Gerenciador.LerString("Número: ");
        c.Endereco.Cep = Gerenciador.LerString("CEP: ");
        c.Endereco.Cidade = Gerenciador.LerString("Cidade: ");

        Cliente[] novosClientes = new Cliente[clientes.Length + 1];
        for (int i = 0; i < clientes.Length; i++)
        {
            novosClientes[i] = clientes[i];
        }
        novosClientes[novosClientes.Length - 1] = c;
        clientes = novosClientes;

        Gerenciador.MostrarMensagem("Cliente cadastrado!");
    }

    public static void Listar()
    {
        for (int i = 0; i < clientes.Length; i++)
        {
            Console.WriteLine($"ID: {clientes[i].Id}, Nome: {clientes[i].Nome}");
        }
    }

    public static void Excluir()
    {
        int id = Gerenciador.LerInteiro("ID para excluir: ");
        int index = -1;
        
        for (int i = 0; i < clientes.Length; i++)
        {
            if (clientes[i].Id == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Gerenciador.MostrarErro("Cliente não encontrado!");
            return;
        }

        Cliente[] clientesAtualizados = new Cliente[clientes.Length - 1];
        int j = 0;
        
        for (int i = 0; i < clientes.Length; i++)
        {
            if (i != index)
            {
                clientesAtualizados[j] = clientes[i];
                j++;
            }
        }

        clientes = clientesAtualizados;
        Gerenciador.MostrarMensagem("Cliente excluído com sucesso!");
    }

    public static Cliente BuscarPorId(int id)
    {
        for (int i = 0; i < clientes.Length; i++)
        {
            if (clientes[i].Id == id)
            {
                return clientes[i];
            }
        }
        return null;
    }
}