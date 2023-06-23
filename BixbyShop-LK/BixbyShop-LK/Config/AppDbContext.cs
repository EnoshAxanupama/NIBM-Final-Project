using BixbyShop_LK.Models.Comments;
using BixbyShop_LK.Models.Item;
using BixbyShop_LK.Models.Order;
using BixbyShop_LK.Users_and_Roles;
using Microsoft.EntityFrameworkCore;
using System;

namespace BixbyShop_LK
{
   public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<CartAndOrder> CartAndOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoles",
                    j => j.HasOne<Roles>().WithMany().HasForeignKey("RoleId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId")
                );

            modelBuilder.Entity<User>()
                .HasMany(u => u.Cart)
                .WithOne(c => c.User);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User);

            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Users)
                .WithMany(u => u.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoleRoles",
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j => j.HasOne<Roles>().WithMany().HasForeignKey("RoleId")
                );

            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Authorities)
                .WithMany(a => a.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleAuthorities",
                    j => j.HasOne<Authority>().WithMany().HasForeignKey("AuthorityName"),
                    j => j.HasOne<Roles>().WithMany().HasForeignKey("RoleName")
                );

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ShopItem)
                .WithMany(si => si.Comments);

            modelBuilder.Entity<CartAndOrder>()
                .HasOne(co => co.User)
                .WithMany(u => u.Cart);

            modelBuilder.Entity<CartAndOrder>()
                .HasOne(co => co.Item)
                .WithMany();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne();
        }
    }
}
