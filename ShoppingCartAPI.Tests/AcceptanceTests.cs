using FluentAssertions;

namespace ShoppingCartAPI.Tests;

public class AcceptanceTests
{
    [Fact(DisplayName = "As customer I want to see my shipping empty cart")]
    public void EmptyCart()
    {
        ShoppingCartService shoppingCartService = new();
        ShoppingCartList actualEmptyCart = shoppingCartService.getShoppingCart();

        actualEmptyCart.Should().BeEquivalentTo(new ShoppingCartList());
    }
}