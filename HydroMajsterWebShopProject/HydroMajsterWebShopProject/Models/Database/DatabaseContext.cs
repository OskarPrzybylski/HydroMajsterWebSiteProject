using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HydroMajsterWebShopProject.Models.Database
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }

    }
}
