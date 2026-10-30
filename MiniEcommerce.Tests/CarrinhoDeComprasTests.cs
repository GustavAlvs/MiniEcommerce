using Xunit;
using MiniEcommerce.ConsoleApp;

namespace MiniEcommerce.Tests;

public class CarrinhoDeComprasTests
{
    [Fact]
    public void DeveAdicionarProdutoAoCarrinho()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.Adicionar(produto, 2);

        Assert.Equal(2, carrinho.QuantidadeDe(produto));
    }

    [Fact]
    public void NaoDeveAdicionarQuantidadeSuperiorAoEstoque()
    {
        var produto = new Produto("Mouse", 50, 3);
        var carrinho = new CarrinhoDeCompras();

        Assert.Throws<InvalidOperationException>(() =>
            carrinho.Adicionar(produto, 5));
    }

    [Fact]
    public void DeveCalcularSubtotalCorretamente()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.Adicionar(produto, 2);

        Assert.Equal(100, carrinho.CalcularSubtotal());
    }

    [Fact]
    public void DeveRemoverProdutoDoCarrinho()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.Adicionar(produto, 2);
        carrinho.Remover(produto);

        Assert.Equal(0, carrinho.QuantidadeDe(produto));
    }
}