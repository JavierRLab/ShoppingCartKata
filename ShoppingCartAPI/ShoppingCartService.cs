namespace ShoppingCartAPI;

public class ShoppingCartService
{
    private IProductService _productService;
    private readonly ShoppingCart _shoppingCart = new();

    public ShoppingCartService(IProductService productService)
    {
        _productService = productService;
    }

    public ShoppingCart GetShoppingCart()
    {
        return _shoppingCart;
    }

    public void Add(string productName)
    {
        var product = _productService.GetProduct(productName);
        _shoppingCart.Products.Add(product);
    }
}


public class ShoppingCart
{
    public readonly List<ProductDTO> Products = new();
    public string Promotion = String.Empty;
    public int TotalProducts = 0;
    public int TotalPrice = 0;
}