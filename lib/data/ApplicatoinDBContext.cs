using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using models;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            // builder.Entity<Portfolio>()
            //     .HasOne(u => u.AppUser)
            //     .WithMany(u => u.Portfolios)
            //     .HasForeignKey(p => p.AppUserId);

            // builder.Entity<Portfolio>()
            //     .HasOne(u => u.Stock)
            //     .WithMany(u => u.Portfolios)
            //     .HasForeignKey(p => p.StockId);
        }
    }
}