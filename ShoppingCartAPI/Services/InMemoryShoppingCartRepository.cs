using ShoppingCartAPI.Data;

namespace ShoppingCartAPI.Services;

public class InMemoryShoppingCartRepository : IShoppingCartRepository
{
    private IProductRepository _productRepository;
    private ShoppingCart _fakeShoppingCart;

    public InMemoryShoppingCartRepository()
    {
        _productRepository = new InMemoryProductRepository();
        _fakeShoppingCart = new()
        {
            ShoppingCartProducts = new List<ShoppingCartProduct>()
        };
    }

    public ShoppingCart GetById(int id)
    {
        return _fakeShoppingCart;
    }

    public void AddProduct(int shoppingCartId, string productName)
    {
        var productToAdd = _productRepository.GetByName(productName);
        var isProductFound = false;

        if (productToAdd is null)
        {
            throw new InvalidOperationException($"Product {productName} does not exist");
        }
        
        foreach (var scp in _fakeShoppingCart.ShoppingCartProducts!)
        {
            if (scp.Product?.Name == productName)
            {
                scp.Quantity += 1;
                isProductFound = true;
            }
        }

        if (!isProductFound)
        {
            var scp = new ShoppingCartProduct
            {
                Product = productToAdd
            };
            _fakeShoppingCart.ShoppingCartProducts.Add(scp);
        }
    }
}