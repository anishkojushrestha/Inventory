using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Project.Models
{
    public class SupplierProduct
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        [ForeignKey("Product")]

        public int? ProductId { get; set; }
        public virtual Supplier Suplier { get; set; }
        public virtual Product Product { get; set; }
    }
}
