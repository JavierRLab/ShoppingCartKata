using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCartAPI.Data;

[Index(nameof(Name))]
public class Product
{

    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public double Cost{ get; set; }
    public double Revenue{ get; set; }
    public double Tax{ get; set; }
    public Product(int id, string name, double cost, double revenue, double tax)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Revenue = revenue;
        Tax = tax;
    }
}