using System;

public class Transportadora
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double PrecoPorKm { get; set; }

    private static Transportadora[] transportadoras = new Transportadora[0];
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
        Transportadora t = new Transportadora();
        t.Id = nextId++;
        t.Nome = Gerenciador.LerString("Nome: ");
        t.PrecoPorKm = Gerenciador.LerDouble("Preço por KM: ");

        Transportadora[] novas = new Transportadora[transportadoras.Length + 1];
        for (int i = 0; i < transportadoras.Length; i++)
        {
            novas[i] = transportadoras[i];
        }
        novas[novas.Length - 1] = t;
        transportadoras = novas;

        Gerenciador.MostrarMensagem("Transportadora cadastrada com sucesso!");
    }

    public static void Listar()
    {
        foreach (Transportadora t in transportadoras)
        {
            Console.WriteLine($"ID: {t.Id}, Nome: {t.Nome}, Preço/KM: {t.PrecoPorKm}");
        }
    }

    public static void Excluir()
    {
        int id = Gerenciador.LerInteiro("ID para excluir: ");

        int index = -1;
        for (int i = 0; i < transportadoras.Length; i++)
        {
            if (transportadoras[i].Id == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Gerenciador.MostrarErro("Transportadora não encontrada!");
            return;
        }

        Transportadora[] atualizadas = new Transportadora[transportadoras.Length - 1];
        int j = 0;
        for (int i = 0; i < transportadoras.Length; i++)
        {
            if (i != index)
            {
                atualizadas[j++] = transportadoras[i];
            }
        }

        transportadoras = atualizadas;
        Gerenciador.MostrarMensagem("Transportadora excluída com sucesso!");
    }

    public static Transportadora BuscarPorId(int id)
    {
        foreach (Transportadora t in transportadoras)
        {
            if (t.Id == id)
                return t;
        }
        return null;
    }
}