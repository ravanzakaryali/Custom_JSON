namespace Custom_JSON.Models;

public class Product
{
    public string Name { get; set; }
    public int OrderId { get; set; }
    public List<Order> Orders { get; set; }
    public Order[] Order { get; set; }
}
