using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI;
using ShoppingCartAPI.Data;
using ShoppingCartAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql("Host=localhost;Username=postgres;Password=5432;Database=postgres"));
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartEntityRepository>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService2>();

var app = builder.Build();

app.CreateDbIfNotExists();


// var productRepo = new InMemoryProductRepository();
// var productRepo = new PostgresProductRepository();
// var productService = new ProductService(productRepo);
// var shoppingCartService = new ShoppingCartService(productService);

app.MapGet("/", () => "Hello World!");
app.MapPost("/add-item", (IShoppingCartService shoppingCartService, ItemRequest request) =>
{
    shoppingCartService.Add(request.ProductName);
    return $"Item {request.ProductName} added";
});

app.MapGet("/shopping-cart", (IShoppingCartService shoppingCartService) =>
{
    var shoppingCart = shoppingCartService.GetShoppingCart();
    var options = new JsonSerializerOptions { WriteIndented = true };
    return JsonSerializer.Serialize(shoppingCart, options);
});

app.Run();

namespace ShoppingCartAPI
{
    public record ItemRequest(string ProductName);
}