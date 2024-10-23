namespace Virtual.Aspire.OrderService.Entities;

public class Order
{
    public int OrderId { get; set; }
    public string UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> Items { get; set; }
}
