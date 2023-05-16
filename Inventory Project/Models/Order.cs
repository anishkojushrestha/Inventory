using System.ComponentModel.DataAnnotations;

namespace Inventory_Project.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveredDate { get; set; }
    }
}
