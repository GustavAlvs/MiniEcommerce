namespace MiniEcommerce.ConsoleApp;

public class CarrinhoDeCompras
{
    private readonly Dictionary<Produto, int> _itens = new();

    public void Adicionar(Produto produto, int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        int quantidadeAtual = QuantidadeDe(produto);

        if (quantidadeAtual + quantidade > produto.QuantidadeEstoque)
            throw new InvalidOperationException("Estoque insuficiente.");

        _itens[produto] = quantidadeAtual + quantidade;
    }

    public void Remover(Produto produto)
    {
        _itens.Remove(produto);
    }

    public int QuantidadeDe(Produto produto)
    {
        return _itens.TryGetValue(produto, out int quantidade)
            ? quantidade
            : 0;
    }

    public decimal CalcularSubtotal()
    {
        return _itens.Sum(item =>
            item.Key.Preco * item.Value);
    }
}