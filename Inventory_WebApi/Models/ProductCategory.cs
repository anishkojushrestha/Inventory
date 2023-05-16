using System.ComponentModel.DataAnnotations;

namespace Inventory_WebApi.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? CategoryName { get; set; }
    }
}
