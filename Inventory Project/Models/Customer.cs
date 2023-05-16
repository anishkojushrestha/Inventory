using System.ComponentModel.DataAnnotations;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Models
{
    public class Customer: IBaseRepo
    {
        [Key]
        public int Id { get; set; }

        public string? CompanyName { get; set; }

        public string? ContactName { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string FileName { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;
    }
}
