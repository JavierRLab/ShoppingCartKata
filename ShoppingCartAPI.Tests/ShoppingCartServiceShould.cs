using FluentAssertions;
namespace ShoppingCartAPI.Tests;

public class ShoppingCartServiceShould
{
    [Fact(DisplayName = "Create empty shopping cart")]
    public void EmptyCart()
    {
        ShoppingCartService shoppingCartService = new();
        ShoppingCart actualEmptyCart = shoppingCartService.GetShoppingCart();

        actualEmptyCart.Should().BeEquivalentTo(new ShoppingCart());
    }
}