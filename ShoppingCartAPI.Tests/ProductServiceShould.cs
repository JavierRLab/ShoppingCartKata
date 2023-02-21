namespace ShoppingCartAPI.Tests;

public class ProductServiceShould
{
    [Fact (DisplayName = "Get Iceberg DTO")]
    public void GetProductReturnProductDTO()
    {
        var productRepository = new Mock<IProductRepository>();
        var productService = new ProductService(productRepository.Object);
        var icebergDto = new ProductDTO("Iceberg", "2.17 €");

        productRepository.Setup(mock => mock.GetProduct("Iceberg"))
            .Returns(new Product("Iceberg", 1.55, 0.15, 0.21));
        
        var actualProduct = productService.GetProduct("Iceberg");
        actualProduct.Should().BeEquivalentTo(icebergDto);
    }

    [Fact(DisplayName = "Product not found")]
    public void ProductNotFound()
    {
        var productRepository = new Mock<IProductRepository>();
        var productService = new ProductService(productRepository.Object);
        Assert.Throws<ArgumentException>(() => productService.GetProduct("Milk"));



    }
}