using Inventory_Project.Repo.IRepo;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Project.Models
{
    public class ProductCategory:IBaseRepo
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string? CategoryName { get; set; }
    }
}
