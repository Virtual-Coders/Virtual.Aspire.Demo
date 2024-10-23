using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Virtual.Aspire.CartService.Entities
{
    public class CartContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }

        public CartContext(DbContextOptions<CartContext> options) : base(options) { }
    }
}
