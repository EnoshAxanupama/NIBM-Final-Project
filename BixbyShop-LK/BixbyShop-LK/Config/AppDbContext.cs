using BixbyShop_LK.Users_and_Roles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixbyShop_LK.Config
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Authority> Authorities { get; set; }

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
        }
    }
}
