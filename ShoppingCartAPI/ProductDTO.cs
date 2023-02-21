namespace ShoppingCartAPI;

public class ProductDTO
{
    public string Name;
    public string Price;

    public ProductDTO(string name, string price)
    {
        Name = name;
        Price = price;
    }
}