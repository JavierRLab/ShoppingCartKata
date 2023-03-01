using System.Globalization;
using ShoppingCartAPI.Services;

namespace ShoppingCartAPI;

public class ShoppingCartService2 : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartService2(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    public ShoppingCartDTO GetShoppingCart()
    {
        var shoppingCartProducts = _shoppingCartRepository.GetShoppingCartProducts(1);

        
        var shoppingCartDto = new ShoppingCartDTO();

        shoppingCartDto.ShoppingCartProducts = shoppingCartProducts;

        double totalPrice = 0;
        
        foreach (var spc in shoppingCartProducts)
        {
            totalPrice += spc.Product!.CalculateFinalPrice() * spc.Quantity;

            shoppingCartDto.TotalQuantity += spc.Quantity;
        }
        
        shoppingCartDto.TotalPrice = PriceToString(totalPrice);

        return shoppingCartDto;
    }

    private static string PriceToString(double totalPrice)
    {
        return Convert.ToString(totalPrice, CultureInfo.InvariantCulture).Replace(',', '.') + " €";
    }

    public void Add(string productName)
    {
        _shoppingCartRepository.AddProduct(1, productName);
    }
}