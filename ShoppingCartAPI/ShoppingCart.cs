using System.Globalization;

namespace ShoppingCartAPI;

public class ShoppingCart
{
    public int TotalQuantity { get; set; }
    public Dictionary<ProductDTO, int> ProductsQuantity { get; } = new();
    public string TotalPrice { get; set; } = "0 €";
}