using BixbyShop_LK.Models.Comments;
using BixbyShop_LK.Models.Item;
using BixbyShop_LK.Models.Order;
using BixbyShop_LK.Users_and_Roles;
using Microsoft.EntityFrameworkCore;
using System;

namespace BixbyShop_LK.Config
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartAndOrder> CartAndOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(join => join.ToTable("UserRoles"));

            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Authorities)
                .WithMany(a => a.Roles)
                .UsingEntity(join => join.ToTable("RoleAuthorities"));

            modelBuilder.Entity<Comment>()
               .HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId);
        }
    }
}
