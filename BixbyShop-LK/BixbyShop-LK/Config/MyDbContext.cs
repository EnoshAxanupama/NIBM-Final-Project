using BixbyShop_LK.Config.DI;
using BixbyShop_LK.Models.Comments;
using BixbyShop_LK.Models.Item;
using BixbyShop_LK.Models.Order;
using BixbyShop_LK.Users_and_Roles;
using Microsoft.EntityFrameworkCore;

namespace BixbyShop_LK.Config
{
    [Component]
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<CartAndOrder> CartAndOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Bixby_ShopAPP_InMemoryDb");
        }
    }
}
