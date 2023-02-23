using System.Globalization;

namespace ShoppingCartAPI;

public class ShoppingCart
{
    public int TotalQuantity { get; private set; }
    public Dictionary<ProductDTO, int> ProductsQuantity { get; } = new();
    public string TotalPrice { get; set; } = "0 €";

    public void Add(ProductDTO product)
    {
        ++TotalQuantity;
        double productPrice = double.Parse(product.Price.Split(" ")[0], CultureInfo.InvariantCulture);
        double currentTotalPrice = double.Parse(TotalPrice.Split(" ")[0], CultureInfo.InvariantCulture);
        double totalPrice = currentTotalPrice + productPrice;
        
        TotalPrice = Convert.ToString(totalPrice).Replace(',', '.') + " €";
        if (ProductsQuantity.TryGetValue(product, out _))
        {
            ++ProductsQuantity[product];
            return;
        }
        
        ProductsQuantity.Add(product, 1);
        
    }
}