using ShoppingCartAPI.Data;
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

        foreach (var spc in shoppingCartProducts)
        {
            double finalPrice = spc.Product.CalculateFinalPrice();
            
            shoppingCartDto.TotalQuantity += spc.Quantity;
        }
        
        
        return shoppingCartDto;
    }

    public void Add(string productName)
    {
        _shoppingCartRepository.AddProduct(1, productName);
    }
}