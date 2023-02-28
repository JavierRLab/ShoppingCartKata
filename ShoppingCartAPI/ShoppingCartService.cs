using System.Globalization;

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
        
        ++_shoppingCart.TotalQuantity;
        
        double productPrice = double.Parse(product.Price.Split(" ")[0], CultureInfo.InvariantCulture);
        double currentTotalPrice = double.Parse(_shoppingCart.TotalPrice.Split(" ")[0], CultureInfo.InvariantCulture);
        double totalPrice = currentTotalPrice + productPrice;
        _shoppingCart.TotalPrice = Convert.ToString(totalPrice).Replace(',', '.') + " €";
        
        if (_shoppingCart.ProductsQuantity.TryGetValue(product, out _))
        {
            ++_shoppingCart.ProductsQuantity[product];
            return;
        }

        _shoppingCart.ProductsQuantity.Add(product, 1);
    }
}