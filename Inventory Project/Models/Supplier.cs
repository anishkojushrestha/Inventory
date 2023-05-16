using System.ComponentModel.DataAnnotations;
using Inventory_Project.Controllers;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Models
{
    public class Supplier : IBaseRepo
    {
        [Key]
        public int Id { get; set; }

        public string? CompanyName { get; set; }

        public string? ContactName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<SupplierProduct> SupplierProduct { get; set; }

        public ICollection<Product> product { get; set; }

        public Supplier()
        {
            SupplierProduct = new HashSet<SupplierProduct>();
            product = new HashSet<Product>();
        }

    }
}
