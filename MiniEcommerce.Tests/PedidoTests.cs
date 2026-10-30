using Xunit;
using MiniEcommerce.ConsoleApp;

namespace MiniEcommerce.Tests;

public class PedidoTests
{
    [Fact]
    public void DeveFinalizarPedidoComSucesso()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.Adicionar(produto, 2);

        var pedido = Pedido.Finalizar(carrinho);

        Assert.Equal(100, pedido.ValorTotal);
    }

    [Fact]
    public void DeveDescontarEstoqueAposCompra()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.Adicionar(produto, 3);

        Pedido.Finalizar(carrinho);

        Assert.Equal(7, produto.QuantidadeEstoque);
    }
}