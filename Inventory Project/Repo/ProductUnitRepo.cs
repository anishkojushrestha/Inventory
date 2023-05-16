using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Repo
{
    public class ProductUnitRepo:Repo<ProductUnit>,IProductUnitRepo
    {
        private ApplicationDbContext _context;
        public ProductUnitRepo(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
    }
}
