using System.Text.Json;
using ShoppingCartAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

var inMemoryProductRepository = new InMemoryProductRepository();
var productService = new ProductService(inMemoryProductRepository);
var shoppingCartService = new ShoppingCartService(productService);

app.MapPost("/add-item", (ItemRequest request) =>
{
    shoppingCartService.Add(request.ProductName);
    return $"Item {request.ProductName} added";
});

app.MapGet("/shopping-cart", () =>
{
    var shoppingCart = shoppingCartService.GetShoppingCart();
    var options = new JsonSerializerOptions { WriteIndented = true };
    return JsonSerializer.Serialize(shoppingCart, options);
});

app.Run();

public record ItemRequest(string ProductName);