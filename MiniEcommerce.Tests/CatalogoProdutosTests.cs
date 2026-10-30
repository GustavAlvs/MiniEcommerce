using Xunit;
using MiniEcommerce.ConsoleApp;

namespace MiniEcommerce.Tests;

public class CatalogoProdutosTests
{
    [Fact]
    public void DeveAdicionarProdutoAoCatalogo()
    {
        var catalogo = new CatalogoProdutos();
        var produto = new Produto("Teclado", 100, 5);

        catalogo.Adicionar(produto);

        Assert.Single(catalogo.Listar());
    }

    [Fact]
    public void DeveListarTodosOsProdutos()
    {
        var catalogo = new CatalogoProdutos();

        catalogo.Adicionar(new Produto("Mouse", 50, 10));
        catalogo.Adicionar(new Produto("Teclado", 100, 5));

        Assert.Equal(2, catalogo.Listar().Count);
    }
}