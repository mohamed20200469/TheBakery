using TheBakery.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.SQL
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity()
                {
                    id = 1,
                    name = "Doughnut",
                    price = 10,
                },
                new ProductEntity()
                {
                    id = 2,
                    name = "Bread",
                    price = 1.5F,
                },
                new ProductEntity()
                {
                    id = 3,
                    name = "Croissant",
                    price = 7.5F,
                }
                );
        }
    }
}