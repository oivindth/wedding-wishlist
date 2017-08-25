using Microsoft.EntityFrameworkCore;

namespace wedding_wishlist.Models
{
    public class WishlistContext : DbContext
    {
        public WishlistContext(DbContextOptions<WishlistContext> options)
            : base(options)
        {
        }

        public DbSet<Wish> Wishes { get; set; }

    }
}