namespace ShoppingCartAPI;

public interface IProductService
{
    public ProductDTO GetProduct(string productName);
}