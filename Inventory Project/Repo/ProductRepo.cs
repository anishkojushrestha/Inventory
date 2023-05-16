using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Repo
{
    public class ProductRepo:Repo<Product>, IProductRepo
    {
        public ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
    }
}
