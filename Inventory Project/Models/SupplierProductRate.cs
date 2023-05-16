using Inventory_Project.Repo.IRepo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Project.Models
{
    public class SupplierProductRate :IBaseRepo
    {
        [Key]
        public int Id { get; set; }

        public int SupplierProductId { get; set; }
        public SupplierProduct? SupplierProduct { get; set; }
        
        public int? UnitId { get; set; }
        public Unit? Unit { get; set; }

        public decimal Rate { get; set; }   
    }
}
