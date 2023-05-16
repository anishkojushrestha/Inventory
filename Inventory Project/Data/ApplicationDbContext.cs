using Inventory_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> customers { set; get; }

        public DbSet<Supplier> suppliers { set; get; }

        public DbSet<ProductUnit> productUnits { set; get; }
        public DbSet<ProductCategory> productCategories { set; get; }
        public DbSet<Product> products { set; get; }

        public DbSet<Unit> units { set; get; }

        public DbSet<SupplierProduct> suppliersProducts { set; get; }

        public DbSet<Order> orders { set; get; }

        public DbSet<OrderDetail> orderDetails { set; get; }

        public DbSet<SupplierProductRate> suppliersProductsRate { set; get; }
        public DbSet<Image> images { set; get; }




    }
}
