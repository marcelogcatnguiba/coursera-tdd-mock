using CourseraMock.Domain.Tests.Entities;
using CourseraMock.Domain.Tests.Interfaces;
using Moq;

namespace CourseraMock.Domain.Tests;

public class CarrinhoCompraTests
{
    private CarrinhoCompra _carrinhoCompra;
    public CarrinhoCompraTests()
    {
        _carrinhoCompra = new();
    }

    [Fact]
    public void DeveAdicionarUmProdutoAoCarrinho()
    {
        bool result = _carrinhoCompra.AdicionaProduto(new Mock<Produto>(10, 1).Object);

        Assert.True(result);
    }

    // [Fact]
    // public void DeveRecuperarUmProduto()
    // {
    //     var carrinhoMock = new Mock<CarrinhoCompra>();
    //     carrinhoMock.Setup(x => x.GetProduto(produtoId)).Returns(produto);
    //     var carrinho = carrinhoMock.Object;

    //     var prod = carrinho.GetProduto(produtoId);

    //     Assert.IsType<Produto>(prod);
    // }

    [Fact]
    public void DeveCalcularValorTotalDoCarrinho()
    {
        _carrinhoCompra.AdicionaProduto(new Mock<Produto>(10, 1).Object);
        _carrinhoCompra.AdicionaProduto(new Mock<Produto>(20, 1).Object);
        _carrinhoCompra.AdicionaProduto(new Mock<Produto>(30, 1).Object);

        int result = _carrinhoCompra.GetValorTotalProdutos();

        Assert.Equal(60, result);
    }

    [Fact]
    public void DeveCalcularValorTotalDoCarrinhoComProdutosMaioresQueUm()
    {
        _carrinhoCompra.AdicionaProduto(new Mock<Produto>(10, 3).Object);
        _carrinhoCompra.AdicionaProduto(new Mock<Produto>(20, 3).Object);
        _carrinhoCompra.AdicionaProduto(new Mock<Produto>(30, 5).Object);

        int result = _carrinhoCompra.GetValorTotalProdutos();

        Assert.Equal(240, result);
    }

    [Fact]
    public void DeveAdicionarObservavel()
    {
        var result = _carrinhoCompra.AdicionarObservavel(new Mock<IObservavel>().Object);

        Assert.True(result);
    }

    [Fact]
    public void DeveConterUmObservavelNaListaDeObservaveis()
    {
        _carrinhoCompra.AdicionarObservavel(new Mock<EstoqueProduto>().Object);

        Assert.True(_carrinhoCompra.ContainObservaveis());
    }

    [Fact]
    public void DeveNotificarUmObservavel()
    {
        var estoqueProduto = new EstoqueProduto();
        var produtoMock = new Mock<Produto>(10, 2).Object;
        estoqueProduto.AdicionarProdutoEstoque(produtoMock);

        _carrinhoCompra.AdicionarObservavel(estoqueProduto);
        _carrinhoCompra.AdicionaProduto(produtoMock);

        Assert.Equal(0, estoqueProduto.GetQuantidadeEstoque());
    }

    [Fact]
    public void DeveRemoverProdutoQuantidadeEstoque()
    {
        EstoqueProduto estoqueProduto = new();
        estoqueProduto.AdicionarProdutoEstoque(new Mock<Produto>(10, 2).Object);
        estoqueProduto.RemoverProdutoEstoque(new Mock<Produto>(10, 2).Object);

        Assert.Equal(0, estoqueProduto.GetQuantidadeEstoque());
    }
}