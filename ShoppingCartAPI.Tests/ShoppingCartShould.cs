namespace ShoppingCartAPI.Tests;

public class ShoppingCartShould
{
    [Fact (DisplayName = "Add 2 similar products to the cart")]
    public void Add2SimilarProductsToCart()
    {
        var icebergDto = new ProductDTO("Iceberg", "2.17 €");

        var shoppingCart = new ShoppingCart();
        shoppingCart.Add(icebergDto);
        shoppingCart.Add(icebergDto);
        
        shoppingCart.ProductsQuantity[icebergDto].Should().Be(2);
    }
}