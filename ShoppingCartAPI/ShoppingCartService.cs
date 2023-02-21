namespace ShoppingCartAPI;

public class ShoppingCartService
{
    private readonly ShoppingCart _shoppingCart = new();

    public ShoppingCart GetShoppingCart()
    {
        return _shoppingCart;
    }
}