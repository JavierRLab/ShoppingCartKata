using Microsoft.EntityFrameworkCore;

namespace ShoppingCartAPI.Data;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}