using FluentAssertions;
using Moq;

namespace ShoppingCartAPI.Tests;

public class AcceptanceTests
{
    [Fact(DisplayName = "As customer I want to see my shipping empty cart")]
    public void EmptyCart()
    {
        var productService = new Mock<IProductService>();
        var shoppingCartService = new ShoppingCartService(productService.Object);
        var actualEmptyCart = shoppingCartService.GetShoppingCart();

        actualEmptyCart.Should().BeEquivalentTo(new ShoppingCart());
    }
    
    [Fact(DisplayName = "Add product to shopping card")]
    public void AddProductToCart()
    {
        var productService = new Mock<IProductService>();
        var shoppingCartService = new ShoppingCartService(productService.Object);

        shoppingCartService.Add("Iceberg");
        var actualCart = shoppingCartService.GetShoppingCart();

        var expectedResult = new ShoppingCart();
        expectedResult.Products.Add(new ProductDTO("Iceberg", "2.17 €"));
        actualCart.Should().BeEquivalentTo(expectedResult);
    }
}