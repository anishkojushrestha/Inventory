using Inventory_Project.Repo.IRepo;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Project.Models
{
    public class Unit:IBaseRepo
    {
        [Key]
        public int Id { get; set; } 

        public string? UnitName { get; set; }

        public decimal? BaseRatio { get; set; }
    }
}
