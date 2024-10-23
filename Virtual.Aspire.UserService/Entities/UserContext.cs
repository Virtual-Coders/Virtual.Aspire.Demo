using Microsoft.EntityFrameworkCore;

namespace Virtual.Aspire.UserService.Entities
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}
