using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RestaurantSystem.Models
{
    public class RestaurantContext : IdentityDbContext<Account>
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Menu> Menu { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
