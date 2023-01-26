using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeenEye.Core.Models;

namespace KeenEye.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<ProductDetails> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductDetails>()
                .HasIndex(u => u.ProductCode)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
