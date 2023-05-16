using System.ComponentModel.DataAnnotations;

namespace Inventory_WebApi.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string? CompanyName { get; set; }

        public string? ContactName { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
