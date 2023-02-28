namespace ShoppingCartAPI.Data;

public static class DbInitializer
{
    public static void Initialize(ProductContext context)
    {
        if (context.Products.Any())
        {
            return;   // DB has been seeded
        }


        var products = new List<Product>();
        products.Add(new Product(1,"Iceberg", 1.55, 0.15, 0.21));
        products.Add(new Product(2,"Tomato", 0.52, 0.15, 0.21));
        products.Add(new Product(3, "Chicken", 1.34, 0.12, 0.21));
        products.Add(new Product(4, "Bread", 0.72, 0.12, 0.10));
        products.Add(new Product(5, "Corn", 1.21, 0.12, 0.10));
        
        context.Products.AddRange(products);
        context.SaveChanges();
    }
}