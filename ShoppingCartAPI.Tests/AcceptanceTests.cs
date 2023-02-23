namespace ShoppingCartAPI.Tests;

public class AcceptanceTests
{
    private readonly IProductRepository _productRepository = new InMemoryProductRepository();
    private readonly IProductService _productService;
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

        var actualProductCart = _shoppingCartService.GetShoppingCart();
        actualProductCart.ProductsQuantity[icebergDto].Should().Be(1);
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