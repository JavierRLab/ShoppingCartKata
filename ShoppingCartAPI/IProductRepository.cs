using ShoppingCartAPI.Data;

namespace ShoppingCartAPI;

public interface IProductRepository
{
    public Product? GetByName(string name);
}