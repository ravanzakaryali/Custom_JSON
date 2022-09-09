// See https://aka.ms/new-console-template for more information
using Custom_JSON;
using Custom_JSON.Models;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");



Product product = new()
{
    Name = "Product1",
    OrderId = 1,
    Orders = new List<Order>
    {
        new Order
        {
            Name = "Order1",
            Orders = new List<Order>
            {
                new Order
                {
                    Name = "Order2"
                }
            }
        }
    }
};


string json = JsonSerializer.Serialize(product);
StringBuilder StringBuilder = new();
string customJson = CustomJSON.Serialze(product);

Console.WriteLine(json);

Console.WriteLine(new string('-', 50));

Console.WriteLine(customJson);