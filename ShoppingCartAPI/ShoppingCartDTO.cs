using System.Globalization;
using ShoppingCartAPI.Data;

namespace ShoppingCartAPI;

public class ShoppingCartDTO
{
    public int TotalQuantity { get; set; }

    public IEnumerable<ShoppingCartProduct>? ShoppingCartProducts { get; set; } = new List<ShoppingCartProduct>();
    public string TotalPrice { get; set; } = "0 €";
}