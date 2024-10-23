namespace Virtual.Aspire.CartService.Entities;

public class Cart
{
    public int CartId { get; set; }
    public string UserId { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
}
