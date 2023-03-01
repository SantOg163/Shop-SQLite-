using Microsoft.EntityFrameworkCore;
using System;

namespace Shop__SQLite_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Genders> Genders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
    }
}