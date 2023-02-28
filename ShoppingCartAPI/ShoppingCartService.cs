using System.Globalization;

namespace ShoppingCartAPI;

public class ShoppingCartService : IShoppingCartService
{
    private IProductService _productService;
    private readonly ShoppingCartDTO _shoppingCartDto = new();

    public ShoppingCartService(IProductService productService)
    {
        _productService = productService;
    }

    public ShoppingCartDTO GetShoppingCart()
    {
        return _shoppingCartDto;
    }

    public void Add(string productName)
    {
        var product = _productService.GetProduct(productName);
        
        ++_shoppingCartDto.TotalQuantity;
        
        double productPrice = double.Parse(product.Price.Split(" ")[0], CultureInfo.InvariantCulture);
        double currentTotalPrice = double.Parse(_shoppingCartDto.TotalPrice.Split(" ")[0], CultureInfo.InvariantCulture);
        double totalPrice = currentTotalPrice + productPrice;
        _shoppingCartDto.TotalPrice = Convert.ToString(totalPrice).Replace(',', '.') + " €";
        
        if (_shoppingCartDto.ProductsQuantity.TryGetValue(product, out _))
        {
            ++_shoppingCartDto.ProductsQuantity[product];
            return;
        }

        _shoppingCartDto.ProductsQuantity.Add(product, 1);
    }
}