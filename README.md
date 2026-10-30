# MiniEcommerce

Sistema de Mini E-commerce desenvolvido em C# com .NET, como atividade prática da disciplina de Garantia da Qualidade de Software.

## Objetivo

Desenvolver um sistema de gerenciamento de produtos e compras, aplicando conceitos de orientação a objetos, testes automatizados e desenvolvimento orientado a testes (TDD).

## Funcionalidades

- Cadastro de produtos.
- Validação de preços e estoques.
- Listagem do catálogo de produtos.
- Adição de produtos ao carrinho.
- Remoção de produtos do carrinho.
- Verificação de disponibilidade em estoque.
- Cálculo do valor total da compra.
- Finalização de pedidos com atualização do estoque.

## Tecnologias utilizadas

- C#
- .NET 10
- xUnit
- Git
- GitHub

## Estrutura do projeto

```text
MiniEcommerce/
├── MiniEcommerce.Console/
│   ├── Program.cs
│   ├── Produto.cs
│   ├── CatalogoProdutos.cs
│   ├── CarrinhoDeCompras.cs
│   └── Pedido.cs
│
├── MiniEcommerce.Tests/
│   ├── ProdutoTests.cs
│   ├── CatalogoProdutosTests.cs
│   ├── CarrinhoDeComprasTests.cs
│   └── PedidoTests.cs
│
├── MiniEcommerce.sln
└── README.md
```

## Como executar

Clone o repositório:

```bash
git clone URL_DO_REPOSITORIO
```

Entre na pasta:

```bash
cd MiniEcommerce
```

Restaure as dependências:

```bash
dotnet restore
```

Execute o sistema:

```bash
dotnet run --project MiniEcommerce.Console
```

## Como executar os testes

Execute:

```bash
dotnet test
```

Os testes automatizados verificam as regras de negócio, validações de produtos, operações do carrinho e finalização de pedidos.

## Qualidade de software

O projeto utiliza testes automatizados com xUnit e práticas de desenvolvimento orientado a testes (TDD), além de commits seguindo o padrão Conventional Commits.

## Autor

Desenvolvido como atividade acadêmica.