using Xunit;
using MiniEcommerce.ConsoleApp;

namespace MiniEcommerce.Tests;

public class ProdutoTests
{
    [Fact]
    public void DeveCriarProdutoComDadosValidos()
    {
        var produto = new Produto("Mouse", 50, 10);

        Assert.Equal("Mouse", produto.Nome);
        Assert.Equal(50, produto.Preco);
        Assert.Equal(10, produto.QuantidadeEstoque);
    }

    [Fact]
    public void NaoDevePermitirPrecoNegativo()
    {
        Assert.Throws<ArgumentException>(() =>
            new Produto("Mouse", -10, 5));
    }

    [Fact]
    public void NaoDevePermitirEstoqueNegativo()
    {
        Assert.Throws<ArgumentException>(() =>
            new Produto("Mouse", 50, -5));
    }
}