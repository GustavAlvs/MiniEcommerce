namespace MiniEcommerce.ConsoleApp;

public class Pedido
{
    public decimal ValorTotal { get; private set; }

    private Pedido(decimal valorTotal)
    {
        ValorTotal = valorTotal;
    }

    public static Pedido Finalizar(CarrinhoDeCompras carrinho)
    {
        if (carrinho.Itens.Count == 0)
            throw new InvalidOperationException("O carrinho está vazio.");

        decimal total = carrinho.CalcularSubtotal();

        foreach (var item in carrinho.Itens)
        {
            item.Key.BaixarEstoque(item.Value);
        }

        return new Pedido(total);
    }
}