using ShoppingCartAPI.Services;

namespace ShoppingCartAPI;

public interface IShoppingCartService
{
    ShoppingCartDTO GetShoppingCart();
    void Add(string productName);
}

public class ShoppingCartService2 : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartService2(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    public ShoppingCartDTO GetShoppingCart()
    {
        return new ShoppingCartDTO();
    }

    public void Add(string productName)
    {
        _shoppingCartRepository.AddProduct(1, productName);
    }
}