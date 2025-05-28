public class Pedido
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
