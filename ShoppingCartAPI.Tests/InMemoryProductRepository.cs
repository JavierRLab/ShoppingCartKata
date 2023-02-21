namespace ShoppingCartAPI.Tests;

public class InMemoryProductRepository : IProductRepository
{
    private Dictionary<string, Product> _products = new Dictionary<string, Product>();

    public InMemoryProductRepository()
    {
        _products.Add("Iceberg", new Product("Iceberg", 1.55, 0.15, 0.21));
        _products.Add("Tomato", new Product("Tomato", 0.52, 0.15, 0.21));
        _products.Add("Chicken", new Product("Chicken", 1.34, 0.12, 0.21));
        _products.Add("Bread", new Product("Bread", 0.72, 0.12, 0.10));
        _products.Add("Corn", new Product("Corn", 1.21, 0.12, 0.10));
    }

    public Product? GetProduct(string productName)
    {
        if (_products.TryGetValue(productName, out var product))
        {
            return product;
        }
        return null;
    }
}