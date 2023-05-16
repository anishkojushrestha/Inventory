using System.ComponentModel.DataAnnotations;

namespace Inventory_Project.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; } 

        public string? UnitName { get; set; }

        public decimal? BaseRatio { get; set; }
    }
}
