using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using AdityaSERA.Backend.Model.Domain;

namespace AdityaSERA.Backend.Services.Persistence
{
    public class AdityaSERADbContext : DbContext
    {
        public AdityaSERADbContext(DbContextOptions<AdityaSERADbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasData(
            //    new Category { CategoryID = 1, CategoryName = "Elektronik" },
            //    new Category { CategoryID = 2, CategoryName = "Pakaian" },
            //    new Category { CategoryID = 3, CategoryName = "Film dan Musik" },
            //    new Category { CategoryID = 4, CategoryName = "Otomotif" },
            //    new Category { CategoryID = 5, CategoryName = "Olahraga" }
            //);
        }

    }
}
