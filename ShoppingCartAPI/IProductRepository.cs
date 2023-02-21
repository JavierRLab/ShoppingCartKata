namespace ShoppingCartAPI;

public interface IProductRepository
{
    public Product? GetProduct(string productName);
}

public class Product
{
    public string Name;
    public double Cost;
    public double Revenue;
    public double Tax;

    public Product(string name, double cost, double revenue, double tax)
    {
        Name = name;
        Cost = cost;
        Revenue = revenue;
        Tax = tax;
    }
}