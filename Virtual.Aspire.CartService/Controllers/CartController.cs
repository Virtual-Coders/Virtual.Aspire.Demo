using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Virtual.Aspire.CartService.Entities;

namespace Virtual.Aspire.CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartContext _context;

        public CartController(CartContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart>> GetCart(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCart), new { userId = cart.UserId }, cart);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateCart(string userId, Cart cart)
        {
            if (userId != cart.UserId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteCart(string userId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
