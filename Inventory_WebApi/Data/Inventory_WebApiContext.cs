using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory_WebApi.Models;
using Inventory_Project.Models;

namespace Inventory_WebApi.Data
{
    public class Inventory_WebApiContext : DbContext
    {
        public Inventory_WebApiContext (DbContextOptions<Inventory_WebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; } = default!;
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Unit> units { get; set; } = default!;
    }
}
