using System.ComponentModel.DataAnnotations;

namespace Inventory_Project.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string? img { get; set; }
    }
}
