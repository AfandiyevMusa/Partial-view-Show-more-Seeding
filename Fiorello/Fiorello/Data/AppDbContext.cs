using System;
using Fiorello.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<SlidersInfo> slidersInfos { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Experts> experts { get; set; }
        public DbSet<Valentine> valentines { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Instagram> instagrams { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<Customer> customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDelete);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "Musa Afandiyev",
                    Age = 19,
                    SoftDelete = false,
                    CreatedDate = DateTime.Now
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Murad Jafarov",
                    Age = 19,
                    SoftDelete = false,
                    CreatedDate = DateTime.Now
                },
                new Customer
                {
                    Id = 3,
                    FullName = "Resul Hasanov",
                    Age = 6,
                    SoftDelete = false,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}

