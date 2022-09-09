namespace Custom_JSON.Models;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
}
