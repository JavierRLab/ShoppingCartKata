using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartAPI.Data;

public class ShoppingCartProduct
{
    [Key, Column(Order = 0)]
    public int ShoppingCartId { get; set; }
    [Key, Column(Order = 1)]
    public int ProductId { get; set; }
    
    public ShoppingCart? ShoppingCart { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; } = 1;
}