namespace ShoppingCartAPI;

public class ShoppingCart
{
    public List<ProductDTO> Products = new();
    public string Promotion = String.Empty;
    public int TotalProducts = 0;
    public int TotalPrice = 0;
}
