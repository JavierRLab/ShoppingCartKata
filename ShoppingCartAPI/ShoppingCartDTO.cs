using System.Globalization;
using ShoppingCartAPI.Data;

namespace ShoppingCartAPI;

public class ShoppingCartDTO
{
    public int TotalQuantity { get; set; }

    public IEnumerable<ShoppingCartProduct> CartItems { get; } = new List<ShoppingCartProduct>();
    public Dictionary<ProductDTO, int> ProductsQuantity { get; } = new();
    public string TotalPrice { get; set; } = "0 €";
}