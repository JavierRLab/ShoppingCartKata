namespace ShoppingCartAPI;

public class ProductDTO
{
    public string Name { get; }
    public string Price { get; }

    public ProductDTO(string name, string price)
    {
        Name = name;
        Price = price;
    }
}