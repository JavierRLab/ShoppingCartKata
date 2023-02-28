using ShoppingCartAPI.Data;
using ShoppingCartAPI.Services;

namespace ShoppingCartAPI.Tests;

public class AcceptanceTests
{
    private readonly IProductRepository _productRepository = new InMemoryProductRepository();
    private readonly IShoppingCartRepository _shoppingCartRepository = new InMemoryShoppingCartRepository();
    private readonly IShoppingCartService _shoppingCartService;

    public AcceptanceTests()
    {
        _shoppingCartService = new ShoppingCartService2(_shoppingCartRepository);
    }
    
    [Fact(DisplayName = "As customer I want to see my shipping empty cart")]
    public void EmptyCart()
    {
        var actualEmptyCart = _shoppingCartService.GetShoppingCart();
        actualEmptyCart.Should().BeEquivalentTo(new ShoppingCartDTO());
    }
    
    [Fact(DisplayName = "Add product to shopping card")]
    public void AddProductToCart()
    {
        _shoppingCartService.Add("Iceberg");

        var actualProductCart = _shoppingCartService.GetShoppingCart();
        
        actualProductCart.CartItems.Count().Should().Be(1);
        actualProductCart.TotalQuantity.Should().Be(1);
        actualProductCart.TotalPrice.Should().Be("2.17 €");
    }
    
    [Fact(DisplayName = "Add 2 similar products to shopping card")]
    public void Add2SimilarProductsToCart()
    {
        var icebergDto = new ProductDTO("Iceberg", "2.17 €");
        
        _shoppingCartService.Add("Iceberg");
        _shoppingCartService.Add("Iceberg");


        var actualProductCart = _shoppingCartService.GetShoppingCart();
        actualProductCart.ProductsQuantity[icebergDto].Should().Be(2);
    }
    
    [Fact(DisplayName = "Add 2 similar and 1 different products to shopping card")]
    public void Add3ProductsToCart()
    {
        _shoppingCartService.Add("Iceberg");
        _shoppingCartService.Add("Iceberg");
        _shoppingCartService.Add("Chicken");

        var actualProductCart = _shoppingCartService.GetShoppingCart();
        actualProductCart.TotalQuantity.Should().Be(3);
    }
    
    [Fact(DisplayName = "Get total price for 3 products")]
    public void GetTotalPriceFor3Products()
    {
        
        _shoppingCartService.Add("Iceberg");
        _shoppingCartService.Add("Iceberg");
        _shoppingCartService.Add("Chicken");

        var actualProductCart = _shoppingCartService.GetShoppingCart();
        actualProductCart.TotalPrice.Should().Be("6.17 €");
    }
}

internal class InMemoryShoppingCartRepository : IShoppingCartRepository
{
    public ShoppingCart? GetById(int id)
    {
        throw new NotImplementedException();
    }
}