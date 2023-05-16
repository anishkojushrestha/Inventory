using Inventory_Project.Repo.IRepo;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Project.Models
{
    public class Product:IBaseRepo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? ProductName { get; set; }

        public int CategoryId { get; set; }

        public ProductCategory? Category { get; set; }

        public int UnitId { get; set; }

        public Unit? Unit { get; set; }   

        public double? UnitPrice { get; set; }
 
    }
}
