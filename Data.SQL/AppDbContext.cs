using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.SQL
{
    public class AppDbContext : IdentityUserContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options): base(options) 
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // ...
        }
        public DbSet<OrderEntity> orders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
