using ShoppingCartAPI.Data;

namespace ShoppingCartAPI.Services;

public interface IShoppingCartRepository
{
    public ShoppingCart? GetById(int id);
}