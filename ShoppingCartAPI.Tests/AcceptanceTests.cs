namespace ShoppingCartAPI.Tests;

public class AcceptanceTests
{
    private IProductRepository _productRepository = new InMemoryProductRepository();
    private IProductService _productService;
    private readonly ShoppingCartService _shoppingCartService;

    public AcceptanceTests()
    {
        _productService = new ProductService(_productRepository);
        _shoppingCartService = new ShoppingCartService(_productService);
    }
    
    [Fact(DisplayName = "As customer I want to see my shipping empty cart")]
    public void EmptyCart()
    {
        var actualEmptyCart = _shoppingCartService.GetShoppingCart();
        actualEmptyCart.Should().BeEquivalentTo(new ShoppingCart());
    }
    
    [Fact(DisplayName = "Add product to shopping card")]
    public void AddProductToCart()
    {
        var icebergDto = new ProductDTO("Iceberg", "2.17 €");
        
        _shoppingCartService.Add("Iceberg");
        var actualCart = _shoppingCartService.GetShoppingCart();
        
        var actualProductCart = _shoppingCartService.GetShoppingCart();
        actualProductCart.Products.Should().ContainEquivalentOf(icebergDto);
    }
}