using ShoppingCartAPI.Data;

namespace ShoppingCartAPI;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public ProductDTO GetProduct(string productName)
    {
        var product = _productRepository.GetByName(productName);
        if (product is null)
            throw new ArgumentException($"Product {productName} doesn't exist");
        
        double finalPrice = CalculateFinalPrice(product);
        var finalPriceStr = Convert.ToString(finalPrice).Replace(',', '.') + " €";
        return new ProductDTO(product.Name, finalPriceStr); 
    }

    private double CalculateFinalPrice(Product product)
    {
        
        var pricePerUnit = Math.Round(product.Cost * (product.Revenue + 1), 2, MidpointRounding.ToPositiveInfinity);
        return Math.Round(pricePerUnit * (product.Tax + 1), 2, MidpointRounding.ToPositiveInfinity);
    }
}