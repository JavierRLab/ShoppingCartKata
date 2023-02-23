namespace ShoppingCartAPI.Tests;

public class ShoppingCartServiceShould
{
    private Mock<IProductService> _productService = new Mock<IProductService>(MockBehavior.Loose);
    private readonly ShoppingCartService _shoppingCartService;


    public ShoppingCartServiceShould()
    {
        _shoppingCartService = new ShoppingCartService(_productService.Object);
        
    }
    
    [Fact(DisplayName = "Create empty shopping cart")]
    public void EmptyCart()
    {
        ShoppingCart actualEmptyCart = _shoppingCartService.GetShoppingCart();

        actualEmptyCart.Should().BeEquivalentTo(new ShoppingCart());
    }
    
    [Fact(DisplayName = "Verify that ProductService GetProduct was invoked")]
    public void InvokeProductServiceGetProduct()
    {  
        var icebergDto = new ProductDTO("Iceberg", "2.17 €");
        _productService.Setup(mock => mock.GetProduct("Iceberg"))
            .Returns(icebergDto);
        
        _shoppingCartService.Add("Iceberg");
        _productService.Verify(mock => mock.GetProduct("Iceberg"));
    }
    
    [Fact(DisplayName = "Add product Iceberg to cart")]
    public void AddProductToCart()
    {
        var icebergDto = new ProductDTO("Iceberg", "2.17 €");
        _productService.Setup(mock => mock.GetProduct("Iceberg"))
            .Returns(icebergDto);
        
        _shoppingCartService.Add("Iceberg");

        var actualProductCart = _shoppingCartService.GetShoppingCart();
        actualProductCart.ProductsQuantity[icebergDto].Should().Be(1);
    }
    
    [Fact (DisplayName = "Add 2 similar products to the cart")]
    public void Add2SimilarProductsToCart()
    {
        var icebergDto = new ProductDTO("Iceberg", "2.17 €");
        
        _productService.Setup(mock => mock.GetProduct("Iceberg"))
            .Returns(icebergDto);

        _shoppingCartService.Add("Iceberg");
        _shoppingCartService.Add("Iceberg");
        
        var actualProductCart = _shoppingCartService.GetShoppingCart();
        actualProductCart.ProductsQuantity[icebergDto].Should().Be(2);
    }
}
