using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBakery.Entities;

namespace Data.SQL
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        public DbSet<OrderEntity> orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>().HasData(
                new OrderEntity()
                {
                    id = 1,
                    ordererName = "ahmed",
                    productId = 1,
                    amount = 1,
                    delivered = false
                });
        }
    }
}
