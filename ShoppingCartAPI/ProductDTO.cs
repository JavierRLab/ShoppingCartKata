namespace ShoppingCartAPI;

public class ProductDTO
{
    private string _name;
    private string _price;
    private int _quantity;

    public ProductDTO(string name, string price)
    {
        _name = name;
        _price = price;
        _quantity = 1;
    }
}