using System.ComponentModel.DataAnnotations;

namespace Inventory_Project.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int UnitId { get; set; }

        public decimal UnitPrice { get; set; }

        public float Quantity { get; set; } 

        public decimal Discount { get; set; }


    }
}
