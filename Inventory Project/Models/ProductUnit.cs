using Inventory_Project.Repo.IRepo;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Project.Models
{
    public class ProductUnit:IBaseRepo
    {
        [Key]
        public int Id { get; set; }
        public int? UnitId { get; set; }
        public Unit? Unit { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal? UnitRate { get; set; } 
        public bool isDefault { get; set; }
    }
}
