using Microsoft.EntityFrameworkCore;

namespace ShoppingCartAPI.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ShoppingCartProduct> ShoppingCartProducts => Set<ShoppingCartProduct>();

}