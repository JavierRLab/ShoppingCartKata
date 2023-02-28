using Npgsql;
using ShoppingCartAPI.Data;

namespace ShoppingCartAPI;

public class PostgresProductRepository : IProductRepository
{
    
    private readonly string cs = "Host=localhost;Username=postgres;Password=5432;Database=postgres";

    public Product? GetByName(string name)
    {
        using (var connection = new NpgsqlConnection(cs))
        {
            connection.Open();
            var sql = "SELECT id, name, cost, revenue, tax " +
                      "FROM products " +
                      $"where name = '{name}'";

            using (var command = new NpgsqlCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    Product? product = null;
                    while (reader.Read())
                    {
                        product = new Product(reader.GetInt32(0),reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3),
                            reader.GetDouble(4));
                    }

                    return product;
                }
            }
        }
    }
}