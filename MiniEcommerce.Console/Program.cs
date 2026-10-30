
using System.Globalization;
using MiniEcommerce.ConsoleApp;

var catalogo = new CatalogoProdutos();
var carrinho = new CarrinhoDeCompras();

bool executando = true;

while (executando)
{
    Console.Clear();

    Console.WriteLine("==============================");
    Console.WriteLine("       MINI E-COMMERCE");
    Console.WriteLine("==============================");
    Console.WriteLine("1 - Cadastrar produto");
    Console.WriteLine("2 - Listar produtos");
    Console.WriteLine("3 - Adicionar ao carrinho");
    Console.WriteLine("4 - Remover do carrinho");
    Console.WriteLine("5 - Visualizar carrinho");
    Console.WriteLine("6 - Finalizar pedido");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("==============================");
    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                Console.Write("Nome do produto: ");
                string nome = Console.ReadLine() ?? "";

                Console.Write("Preço: ");
                if (!decimal.TryParse(
                    Console.ReadLine(),
                    NumberStyles.Number,
                    CultureInfo.GetCultureInfo("pt-BR"),
                    out decimal preco))
                {
                    Console.WriteLine("Preço inválido.");
                    break;
                }

                Console.Write("Quantidade em estoque: ");
                if (!int.TryParse(Console.ReadLine(), out int estoque))
                {
                    Console.WriteLine("Quantidade inválida.");
                    break;
                }

                var novoProduto = new Produto(nome, preco, estoque);
                catalogo.Adicionar(novoProduto);

                Console.WriteLine("Produto cadastrado com sucesso!");
                break;

            case "2":
                Console.WriteLine("\n=== CATÁLOGO ===");

                var produtos = catalogo.Listar();

                if (produtos.Count == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }

                foreach (var produto in produtos)
                {
                    Console.WriteLine(
                        $"{produto.Nome} | R$ {produto.Preco:F2} | Estoque: {produto.QuantidadeEstoque}");
                }
                break;

            case "3":
                Console.WriteLine("\n=== ADICIONAR AO CARRINHO ===");

                var listaProdutos = catalogo.Listar();

                for (int i = 0; i < listaProdutos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {listaProdutos[i].Nome} | Estoque: {listaProdutos[i].QuantidadeEstoque}");
                }

                Console.Write("Número do produto: ");

                if (!int.TryParse(Console.ReadLine(), out int indice) ||
                    indice < 1 || indice > listaProdutos.Count)
                {
                    Console.WriteLine("Produto inválido.");
                    break;
                }

                Console.Write("Quantidade desejada: ");

                if (!int.TryParse(Console.ReadLine(), out int quantidade))
                {
                    Console.WriteLine("Quantidade inválida.");
                    break;
                }

                carrinho.Adicionar(listaProdutos[indice - 1], quantidade);

                Console.WriteLine("Produto adicionado ao carrinho!");
                break;

            case "4":
                Console.WriteLine("\n=== REMOVER DO CARRINHO ===");

                Console.Write("Nome do produto: ");
                string nomeRemover = Console.ReadLine() ?? "";

                var produtoRemover = carrinho.Itens.Keys.FirstOrDefault(
                    p => p.Nome.Equals(nomeRemover, StringComparison.OrdinalIgnoreCase));

                if (produtoRemover == null)
                {
                    Console.WriteLine("Produto não encontrado no carrinho.");
                }
                else
                {
                    carrinho.Remover(produtoRemover);
                    Console.WriteLine("Produto removido!");
                }
                break;

            case "5":
                Console.WriteLine("\n=== SEU CARRINHO ===");

                if (carrinho.Itens.Count == 0)
                {
                    Console.WriteLine("Carrinho vazio.");
                }

                foreach (var item in carrinho.Itens)
                {
                    Console.WriteLine(
                        $"{item.Key.Nome} | Quantidade: {item.Value} | Subtotal: R$ {item.Key.Preco * item.Value:F2}");
                }

                Console.WriteLine($"TOTAL: R$ {carrinho.CalcularSubtotal():F2}");
                break;

            case "6":
                var pedido = Pedido.Finalizar(carrinho);

                Console.WriteLine("\n=== PEDIDO FINALIZADO ===");
                Console.WriteLine($"Valor total: R$ {pedido.ValorTotal:F2}");
                Console.WriteLine("Estoque atualizado com sucesso!");

                carrinho = new CarrinhoDeCompras();
                break;

            case "0":
                executando = false;
                Console.WriteLine("Obrigado por utilizar o MiniEcommerce!");
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }

    if (executando)
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}
