using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI;
using ShoppingCartAPI.Data;
using ShoppingCartAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseNpgsql("Host=localhost;Username=postgres;Password=5432;Database=postgres"));
builder.Services.AddScoped<IProductRepository, ProductEntityRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ShoppingCartService>();

var app = builder.Build();

app.CreateDbIfNotExists();


// var productRepo = new InMemoryProductRepository();
// var productRepo = new PostgresProductRepository();
// var productService = new ProductService(productRepo);
// var shoppingCartService = new ShoppingCartService(productService);

app.MapGet("/", () => "Hello World!");
app.MapPost("/add-item", (ShoppingCartService shoppingCartService, ItemRequest request) =>
{
    
    shoppingCartService.Add(request.ProductName);
    return $"Item {request.ProductName} added";
});

app.MapGet("/shopping-cart", (ShoppingCartService shoppingCartService) =>
{
    var shoppingCart = shoppingCartService.GetShoppingCart();
    var options = new JsonSerializerOptions { WriteIndented = true };
    return JsonSerializer.Serialize(shoppingCart, options);
});

app.Run();

public record ItemRequest(string ProductName);