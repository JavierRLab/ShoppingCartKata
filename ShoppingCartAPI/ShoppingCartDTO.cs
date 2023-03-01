using System.Globalization;
using ShoppingCartAPI.Data;

namespace ShoppingCartAPI;

public class ShoppingCartDTO
{
    public int TotalQuantity { get; set; }

    public IEnumerable<ShoppingCartProduct>? ShoppingCartProducts { get; set; } = new List<ShoppingCartProduct>();
    public Dictionary<ProductDTO, int> ProductsQuantity { get; } = new();
    public string TotalPrice { get; set; } = "0 €";
}