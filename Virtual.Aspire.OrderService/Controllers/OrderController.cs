using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Virtual.Aspire.OrderService.Entities;

namespace Virtual.Aspire.OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderContext _context;

    public OrderController(OrderContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders(string userId)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.Items)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrders), new { userId = order.UserId }, order);
    }
}
