namespace MiniEcommerce.ConsoleApp;

public class CatalogoProdutos
{
    private readonly List<Produto> _produtos = new();

    public void Adicionar(Produto produto)
    {
        _produtos.Add(produto);
    }

    public IReadOnlyList<Produto> Listar()
    {
        return _produtos.AsReadOnly();
    }
}