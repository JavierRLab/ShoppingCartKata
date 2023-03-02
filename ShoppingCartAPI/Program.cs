using System.Collections.Immutable;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI;
using ShoppingCartAPI.Data;
using ShoppingCartAPI.Services;

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddEnvironmentVariables();
var config = configurationBuilder.Build();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options =>
{
    var connectionString =
        $"Host={config["RDS_HOSTNAME"]};Username={config["RDS_USERNAME"]};Password={config["RDS_PASSWORD"]};Database={config["RDS_DB_NAME"]};";
    if(builder.Environment.IsDevelopment())
        connectionString = builder.Configuration.GetConnectionString("MyDbConnectionString");
    options.UseNpgsql(connectionString);
});
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